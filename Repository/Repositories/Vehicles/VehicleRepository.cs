using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;
using System.Data.Entity;

namespace Entra21.CSharp.Area21.Repository.Repositories.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ShortTermParkingContext _context;

        public VehicleRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
                return false;

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();

            return true;
        }

        public Vehicle Insert(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return vehicle;
        }

        public void Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }

        // INNER JOIN com a tabela de Usuario
        public Vehicle? GetById(int id) =>
            _context.Vehicles
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);


        public IList<Vehicle> GetAll() =>
            _context.Vehicles
            .Include(_x => _x.User)
            .ToList();
    }
}
