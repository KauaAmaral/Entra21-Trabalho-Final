using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Notifications;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;

namespace Entra21.CSharp.Area21.Service.Services.Notifications
{
    public class NotificationService : INotificationService
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
    }
}
