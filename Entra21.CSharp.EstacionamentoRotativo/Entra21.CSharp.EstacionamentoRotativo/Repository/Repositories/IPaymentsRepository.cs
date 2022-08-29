using Repository.Entities;

namespace Repository.Repositories
{
    public interface IPaymentsRepository
    {
        Payments Cadastrar(Payments payments);
    }
}