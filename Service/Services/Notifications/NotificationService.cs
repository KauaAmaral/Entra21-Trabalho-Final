using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Repository.Repositories.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Vehicles;

namespace Entra21.CSharp.Area21.Service.Services.Notifications
{
    internal class NotificationService : INotificationService
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
            var vehicles = _vehicleService.GetAllById(id);

            var notifications = new List<Notification>();
            for (int i = 0; i < vehicles.Count; i++)
            {
                var notificationCurrent = _notificationRepository.GetByVehicleId(vehicles[i].Id);

                if (notificationCurrent != null)
                    notifications.AddRange(notificationCurrent); 
            }

            return notifications;
        }
    }
}
