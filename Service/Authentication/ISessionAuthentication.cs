using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Service.Authentication
{
    public interface ISessionAuthentication
    {
        void CreateUserSession(User user);
        void RemoveUserSession();
        User FindUserSession();

    }
}
