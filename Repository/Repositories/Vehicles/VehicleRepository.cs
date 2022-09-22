using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.Area21.Repository.Repositories.Vehicles
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        private readonly ShortTermParkingContext _context;

        public VehicleRepository(ShortTermParkingContext context) : base(context)
        {
            _context = context;
        }

        // INNER JOIN com a tabela de Usuario
        public override Vehicle? GetById(int id) =>
            _context.Vehicles
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        public override IList<Vehicle> GetAll() =>
            _context.Vehicles
            .Include(x => x.User)
            .ToList();

        public IList<Vehicle> GetAllById(int id) =>
            _context.Vehicles
            .Include(x => x.User)
            .Where(x => x.User.Id == id)
            .ToList();
    }
}