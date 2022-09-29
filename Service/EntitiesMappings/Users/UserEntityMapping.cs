using Entra21.CSharp.Area21.Repository.Authentication;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Users
{
    public class UserEntityMapping : IUserEntityMapping
    {
        public User RegisterWith(UserRegisterViewModel viewModel) =>
            new User
            {
                Name = viewModel.Name,
                Token = viewModel.Token,
                TokenExpiredDate = DateTime.Now.AddHours(2),
                Email = viewModel.Email,
                Password = viewModel.Password.GetHash(),
                Cpf = viewModel.Cpf,
                Hierarchy = viewModel.Hierarchy,
                CreatedAt = DateTime.Now
            };

        public User UpdateWith(User user, UserUpdateViewModel viewModel)
        {
            user.Name = viewModel.Name;
            user.Email = viewModel.Email;
            user.Cpf = viewModel.Cpf;
            user.Phone = viewModel.Phone;
            user.UpdatedAt = DateTime.Now;

            return user;
        }      

        public User UpdateWithAdministrator(User user, UserUpdateAdministratorViewModel viewModel)
        {
            user.Name = viewModel.Name;
            user.Email = viewModel.Email;
            user.Cpf = viewModel.Cpf;
            user.Phone = viewModel.Phone;
            user.UpdatedAt = DateTime.Now;
            user.Hierarchy = viewModel.Hierarchy;

            if (viewModel.Password != null)
                user.Password = viewModel.Password;

            return user;
        }      
        
        public User UpdatePasswordWith(User user, UserChangePasswordViewModel viewModel)
        {
            user.Password = viewModel.NewPassword.GetHash();
            user.UpdatedAt = DateTime.Now;

            return user;
        }
    }
}
