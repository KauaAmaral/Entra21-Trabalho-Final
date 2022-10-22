using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.Area21.Repository.Repositories.Notifications
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private readonly ShortTermParkingContext _context;

        public NotificationRepository(ShortTermParkingContext context) : base(context)
        {
            _context = context;
        }

        public override Notification? GetById(int id) =>
            _context.Notifications
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .FirstOrDefault(x => x.Id == id);

        public override IList<Notification> GetAll() =>
            _context.Notifications
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .Include(x => x.Guard.User)
            .ToList();


        public Notification? GetByPlate(string plate) =>
            _context.Notifications
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .OrderByDescending(x => x.Id)
            .FirstOrDefault(x => x.VehicleLicensePlate == plate);

        public IList<Notification> GetByVehicleId(int id) =>
            _context.Notifications
            .Include(x => x.Guard)
            .Include(x => x.Vehicle)
            .Where(x => x.VehicleId == id)
            .ToList();
    }
}