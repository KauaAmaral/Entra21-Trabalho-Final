using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Notifications
{
    public interface INotificationRepository
    {
        Notification NewNotification(Notification notification);
        void UpdateNotification(Notification notification);
        Notification? GetById(int id);
        IList<Notification> GetAll();
    }
}