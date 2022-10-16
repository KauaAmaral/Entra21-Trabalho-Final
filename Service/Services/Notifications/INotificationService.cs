using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;

namespace Entra21.CSharp.Area21.Service.Services.Notifications
{
    public interface INotificationService
    {
        Notification Register(NotificationRegisterViewModel viewModel);
        bool Update(NotificationUpdateViewModel viewModel);
        bool Delete(int id);
        Notification? GetById(int id);
        IList<Notification> GetByVehicleId(int id);
        IList<Notification> GetAll();
        void CreatePdfNotifications(Notification notification, string link);
        Notification UpdateNotificationAmount(Notification notification);
        Notification SetNotification(NotificationRegisterViewModel viewModel);
    }
}