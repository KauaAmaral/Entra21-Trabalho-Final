using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.Services.Users
{
    public interface IUserService
    {
        bool Delete(int id);
        User Insert(UserRegisterViewModel viewModel);
        bool Update(UserUpdateViewModel viewModel);
        User? GetById(int id);
        IList<User> GetAll();
        User? GetByEmailAndPassword(string email, string password);
    }
}
