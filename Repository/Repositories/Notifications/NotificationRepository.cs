﻿using Entra21.CSharp.Area21.Repository.Entities;
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

        public Notification? ObterPorId(int id) =>
            _context.Notification
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .FirstOrDefault(x => x.Id == id);

        public IList<Notification> ObterTodos() =>
            _context.Notification
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .ToList();
    }
}
