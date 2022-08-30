using Entra21.CSharp.Area21.RepositoryDataBase;
using Entra21.CSharp.Area21.RepositoryEntities;

namespace Entra21.CSharp.Area21.RepositoryRepositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly ShortTermParkingContext _context;

        public PaymentsRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public Payment Cadastrar(Payment payments)
        {
            _context.Payments.Add(payments);
            _context.SaveChanges();

            return payments;
        }
    }
}
