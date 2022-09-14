using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.Services.Guards
{
    public interface IGuardService
    {
        bool Delete(int id);
        Guard Register(GuardRegisterViewModel viewModel);
        Guard? GetById(int id);
        IList<Guard> GetAll();
        bool Disable(User userChange);
    }
}