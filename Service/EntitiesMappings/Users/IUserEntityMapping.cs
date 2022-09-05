using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Users
{
    public interface IUserEntityMapping
    {
        User RegisterWith(UserRegisterViewModel viewModel);
        User UpdateWith(User user, UserUpdateViewModel viewModel);
    }
}
