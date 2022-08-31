using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Users
{
    public interface IUserEntityMapping
    {
        User RegisterWith(UserRegisterViewModel viewModel);
        void UpdateWith(User user, UserUpdateViewModel viewModel);
    }
}
