using Entra21.CSharp.Area21.RepositoryDataBase;
using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Payments
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly ShortTermParkingContext _context;

        public PaymentsRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public Payment Register(Payment payments)
        {
            _context.Payments.Add(payments);
            _context.SaveChanges();

            return payments;
        }
    }
}


