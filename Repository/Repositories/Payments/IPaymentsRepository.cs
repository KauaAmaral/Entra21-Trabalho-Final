using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Payments
{
    public interface IPaymentsRepository
    {
        Payment Register(Payment payments);
    }
}