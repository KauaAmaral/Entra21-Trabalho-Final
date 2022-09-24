using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.Services.Guards
{
    public interface IGuardService
    {
        Guard Register(GuardRegisterViewModel viewModel);
        IList<Guard> GetAll();
        Guard GetById(int id);
        bool Update(GuardUpdateViewModel viewModel);
        void Delete(int id);
    }
}