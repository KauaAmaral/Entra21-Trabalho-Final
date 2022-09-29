using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.Area21.Repository.Repositories.Guards
{
    public class GuardRepository : GenericRepository<Guard>, IGuardRepository
    {
        private readonly ShortTermParkingContext _context;

        public GuardRepository(ShortTermParkingContext context) : base(context)
        {
            _context = context;
        }

        public override Guard? GetById(int id) =>
            _context.Guards
                .Include(x => x.Id)
                .FirstOrDefault(x => x.Id == id);

        public override IList<Guard> GetAll() =>
            _context.Guards
                .Include(x => x.User)
                .ToList();

        public Guard GetByIdUser(int id) =>
            _context.Guards
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
    }
}