using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Users
{
    internal interface IUserRepository
    {
        User Cadastrar(User user);
        void Editar(User user);
        bool Apagar(int id);
        User? ObterPorId(int id);
        IList<User> ObterTodos();
    }
}
