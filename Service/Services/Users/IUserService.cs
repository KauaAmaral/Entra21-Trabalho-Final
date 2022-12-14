using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.Services.Users
{
    public interface IUserService
    {
        bool Delete(int id);
        User Insert(UserRegisterViewModel viewModel);
        User InsertAdministrator(UserRegisterViewModel viewModel);
        bool Update(UserUpdateViewModel viewModel);
        User UpdateAdministrator(UserUpdateAdministratorViewModel viewModel);
        User? GetById(int id);
        IList<User> GetAll();
        User? GetByEmailAndPassword(string email, string password);
        User? GetByCpf(string cpf);
        bool UpdatePassword(UserChangePasswordViewModel viewModel);
        User UpdateVerifyEmail(int id);
        bool Disable(User userChange);
        bool VerifyEmails(string email);
        UserUpdateAdministratorViewModel? GetViewModelById(int id);
    }
}