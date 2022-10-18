using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Repository.Repositories.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QRCoder;
using System.Drawing;

namespace Entra21.CSharp.Area21.Service.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationEntityMapping _notificationEntityMapping;
        private readonly IVehicleService _vehicleService;



        public NotificationService(INotificationRepository notificationRepository,
            INotificationEntityMapping notificationEntityMapping,
            IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            _notificationRepository = notificationRepository;
            _notificationEntityMapping = notificationEntityMapping;
        }

        public Notification SetNotification(NotificationRegisterViewModel viewModel)
        {
            var notification = new Notification();
            notification = _notificationRepository.GetByPlate(viewModel.VehiclePlate);

            if (notification == null || notification.CreatedAt.Date != DateTime.Now.Date || notification.Address != viewModel.Address || notification.PayerId != null)
            {
                return Register(viewModel);
            }
            else if (notification.CreatedAt.AddHours(1) <= DateTime.Now && notification.NotificationAmount == 1)
            {
                return UpdateNotificationAmount(notification);
            }

            return UpdateNotificationAmount(notification);
        }

        public Notification Register(NotificationRegisterViewModel viewModel)
        {
            viewModel.NotificationAmount = 1;
            if ((int)viewModel.Type == 0)
                viewModel.Value = Convert.ToDecimal(15);
            else
                viewModel.Value = Convert.ToDecimal(7.50);

            var notification = _notificationEntityMapping.RegisterWith(viewModel);

            notification.CreatedAt = DateTime.Now;

            _notificationRepository.Add(notification);

            return notification;
        }

        public Notification UpdateNotificationAmount(Notification notification)
        {
            notification.NotificationAmount = notification.NotificationAmount + 1;
            notification.UpdatedAt = DateTime.Now;

            if ((int)notification.Type == 0)
                notification.Value = Convert.ToDecimal(16.50);
            else
                notification.Value = Convert.ToDecimal(8.25);

            _notificationRepository.Update(notification);

            return notification;
        }

        public bool Update(NotificationUpdateViewModel viewModel)
        {
            var notification = _notificationRepository.GetById(viewModel.Id);

            if (notification == null)
                return false;

            if (viewModel.Token == null)
                notification = _notificationEntityMapping.UpdateWith(notification, viewModel);
            else
                notification = _notificationEntityMapping.UpdateWithPayment(notification, viewModel);

            _notificationRepository.Update(notification);

            return true;
        }

        public Notification? GetById(int id) =>
            _notificationRepository.GetById(id);

        public IList<Notification> GetAll() =>
            _notificationRepository.GetAll();

        public IList<Notification> GetByVehicleId(int id)
        {
            var vehicles = _vehicleService.GetByUserId(id);

            var notifications = new List<Notification>();
            for (int i = 0; i < vehicles.Count; i++)
            {
                var notificationCurrent = _notificationRepository.GetByVehicleId(vehicles[i].Id);

                if (notificationCurrent != null)
                    notifications.AddRange(notificationCurrent); 
            }

            return notifications;
        }

        public bool Delete(int id) =>
            _notificationRepository.Delete(id);

        public void CreatePdfNotifications(Notification notification, string link)
        {
            var fileName = $"..\\Application\\wwwroot\\Theme\\global\\notifications\\{notification.VehicleLicensePlate}.{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}.pdf";
            var file = new FileStream(fileName, FileMode.Create);
            var pxByMm = 72 / 25.2F;
            var document = new Document(PageSize.A4, 15 * pxByMm, 15 * pxByMm, 15 * pxByMm, 20 * pxByMm);
            var writer = PdfWriter.GetInstance(document, file);

            var logoPath = "..\\Application\\wwwroot\\Theme\\global\\portraits\\Logo Black.png";
            
            document.Open();

            var logo = iTextSharp.text.Image.GetInstance(logoPath);
            logo.ScaleToFit(152, 65);

            logo.Alignment = Element.ALIGN_CENTER;

            document.Add(logo);

            var qrCode = (System.Drawing.Image)CreateQrCode(link);
            
            var image = iTextSharp.text.Image.GetInstance(qrCode, BaseColor.BLACK);

            image.Alignment = Element.ALIGN_CENTER;

            image.ScaleToFit(300, 300);

            var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            var fontParagraph = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            var fontTitle = new iTextSharp.text.Font(baseFont, 26, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            var title = new Paragraph($"Notificação - {notification.VehicleLicensePlate}", fontTitle);
            title.Alignment = Element.ALIGN_LEFT;
            document.Add(title);

            var paragraph1 = new Paragraph(@$"
Você estacionou seu veículo de placa {notification.VehicleLicensePlate} sem apresentar um cartão área azul ou pagamento digital. Para pagar esta notificação, você deverá entrar no site por meio do QR code abaixo, ou pelo link {link}:", fontParagraph);
            document.Add(paragraph1);
            document.Add(image);

            var paragraph2 = new Paragraph(@$"
Caso não seja pago no tempo de quinze dias, o valor será passado de R$ 7,50 para R$ 12,50.
", fontParagraph);
            document.Add(paragraph2);

            document.Close();
        }

        public Bitmap CreateQrCode(string url)
        {
            var qrCodeGenerator = new QRCodeGenerator();
            var qrCodeData = qrCodeGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }
    }
}
