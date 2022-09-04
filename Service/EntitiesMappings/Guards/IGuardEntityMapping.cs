using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Guards
{
    public interface IGuardEntityMapping
    {
        Guard RegisterWith(GuardRegisterViewModel viewModel, string path);
        void UpdateWith(Guard guard, GuardUpdateViewModel viewModel, string path);
    }
}
