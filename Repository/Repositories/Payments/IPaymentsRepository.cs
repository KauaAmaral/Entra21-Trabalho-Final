using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;

namespace Entra21.CSharp.Area21.Repository.Repositories.Payments
{
    public interface IPaymentsRepository : IGenericRepository<Payment>
    {
        Payment? ValidPayment(int id);
        Payment? GetByTransactionId(string transactionId);
        List<Payment>? GetLocations();
    }
}