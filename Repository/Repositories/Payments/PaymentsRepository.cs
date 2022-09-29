using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.Area21.Repository.Repositories.Payments
{
    public class PaymentsRepository : GenericRepository<Payment>, IPaymentsRepository
    {
        private readonly ShortTermParkingContext _context;

        public PaymentsRepository(ShortTermParkingContext context) : base(context)
        {
            _context = context;
        }

        public override IList<Payment> GetAll() =>
            _context.Payments
            .Include(x => x.Vehicle)
            .ToList();

        public override Payment? GetById(int id) =>
          _context.Payments
          .Include(x => x.Vehicle)
          .Include(x => x.User)
          .FirstOrDefault(x => x.Id == id);
    }
}


