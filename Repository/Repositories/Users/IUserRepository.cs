using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;

namespace Entra21.CSharp.Area21.Repository.Repositories.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {       
        User? GetByEmailAndPassword(string email, string password);
        IList<User>? GetActiveUsers();
    }
}
