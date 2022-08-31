using Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Guards
{
    public interface IGuardRepository
    {
        Guard Cadastrar(Guard guard);
        void Editar(Guard guard);
        bool Apagar(int id);
        Guard? ObterPorId(int id);
        IList<Guard> ObterTodos();
    }
}