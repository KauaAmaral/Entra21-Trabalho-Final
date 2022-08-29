using Repository.Entities;

namespace Repository.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly ShortTermParkingContext _context;

        public PaymentsRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public Payments Cadastrar(Payments payments)
        {
            _context.Payments.Add(payments);
            _context.SaveChanges();

            return payments;
        }
    }
}
