using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;

namespace Entra21.CSharp.Area21.Service.Services.Notifications
{
    internal interface INotificationService
    {
        Notification Register(NotificationRegisterViewModel viewModel);
        bool Update(NotificationUpdateViewModel viewModel);
        Notification? GetById(int id);
        IList<Notification> GetAll();
    }
}