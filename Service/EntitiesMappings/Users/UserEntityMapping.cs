using Entra21.CSharp.Area21.Repository.Authentication;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Users
{
    internal class UserEntityMapping : IUserEntityMapping
    {
        public User RegisterWith(UserRegisterViewModel viewModel) =>
            new User
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Password = viewModel.Password.GetHash(),
                Cpf = viewModel.Cpf,
                Phone = viewModel.Phone,
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
    }
}
