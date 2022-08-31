using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;
using System.Data.Entity;

namespace Entra21.CSharp.Area21.Repository.Repositories.Notifications
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ShortTermParkingContext _context;

        public NotificationRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public Notification NewNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return notification;
        }

        public void UpdateNotification(Notification notification)
        {
            _context.Notifications.Update(notification);
            _context.SaveChanges();
        }

        public Notification? ObterPorId(int id) =>
            _context.Notifications
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .FirstOrDefault(x => x.Id == id);

        public IList<Notification> ObterTodos() =>
            _context.Notifications
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .ToList();
    }
}