using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.Area21.Service.Services.Users
{
    internal interface IUserService
    {
        bool Delete(int id);
        User Insert(UserViewModel viewModel);
        bool Update(UserUpdateViewModel viewModel);
        UserUpdateViewModel? GetById(int id);
        IList<User> GetAll();
    }
}
