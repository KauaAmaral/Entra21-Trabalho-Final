using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories
{
    public interface IPaymentsRepository
    {
        Payment Cadastrar(Payment payments);
    }
}