using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications
{
    public class NotificationEntityMapping : INotificationEntityMapping
    {
        public Notification RegisterWith(NotificationRegisterViewModel viewModel) =>
            new Notification
            {
                Address = viewModel.Address,
                CreatedAt = DateTime.Now
            };

        public Notification UpdateWith(Notification notification, NotificationUpdateViewModel viewModel)
        {
            notification.Address = viewModel.Address;
            notification.UpdatedAt = DateTime.Now; 

            return notification;
        }
    }
}
