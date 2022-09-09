using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications
{
    public interface INotificationEntityMapping
    {
        Notification RegisterWith(NotificationRegisterViewModel viewModel);
        Notification UpdateWith(Notification notification, NotificationUpdateViewModel viewModel);
    }
}