using Entra21.CSharp.Area21.RepositoryEntities;

namespace Entra21.CSharp.Area21.RepositoryRepositories
{
    public interface IPaymentsRepository
    {
        Payment Cadastrar(Payment payments);
    }
}