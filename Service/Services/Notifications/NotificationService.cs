using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Notifications;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Entra21.CSharp.Area21.Service.Services.Notifications
{
    internal class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationEntityMapping _notificationEntityMapping;

        public NotificationService(INotificationRepository notificationRepository,
            INotificationEntityMapping notificationEntityMapping)
        {
            _notificationRepository = notificationRepository;
            _notificationEntityMapping = notificationEntityMapping;
        }

        public Notification Register(NotificationRegisterViewModel viewModel)
        {
            var notification = _notificationEntityMapping.RegisterWith(viewModel);

            _notificationRepository.Add(notification);

            return notification;
        }

        public bool Update(NotificationUpdateViewModel viewModel)
        {
            var notification = _notificationRepository.GetById(viewModel.Id);

            if (notification == null)
                return false;

            notification = _notificationEntityMapping.UpdateWith(notification, viewModel);

            _notificationRepository.Update(notification);

            return true;
        }

        public Notification? GetById(int id) =>
            _notificationRepository.GetById(id);

        public IList<Notification> GetAll() =>
            _notificationRepository.GetAll();

        public void CreatePdfNotifications(Notification notification, string link)
        {
            var fileName = $"..\\Application\\wwwroot\\Theme\\global\\notifications\\{notification.Vehicle.User}.{DateTime.Now.ToString("dd/MM/yyyy-HH:mm:ss")}";
            var file = new FileStream(fileName, FileMode.Create);
            var document = new Document(PageSize.A4);

            document.Open();

            var baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);

            var fontParagraph = new Font(baseFont, 16, Font.NORMAL, BaseColor.BLACK);
            var fontTitle = new Font(baseFont, 32, Font.NORMAL, BaseColor.BLACK);

            var title = new Paragraph($"Notificação - {notification.Vehicle.LicensePlate}");
            document.Add(title);

            var paragraph = new Paragraph(@$"
{notification.Vehicle.User.Name}, você estacionou seu veículo de placa {notification.Vehicle.LicensePlate} sem apresentar um cartão área azul ou pagamento digital.
Para pagar esta notificação, você deverá entrar no site por meio do QR code abaixo, ou pelo link {link}:

Caso não seja pago no tempo de quinze dias, o valor será passado de R$ 7,50 para R$ 12,50.
");
            document.Add(paragraph)
        }
    }
}
