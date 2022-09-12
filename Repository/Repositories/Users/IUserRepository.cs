using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Users
{
    public interface IUserRepository
    {
        User Insert(User user);
        void Update(User user);
        bool Delete(int id);
        User? GetById(int id);
        IList<User> GetAll();
        User? GetByEmailAndPassword(string email, string password);
        IList<User>? GetActiveUsers();
    }
}
