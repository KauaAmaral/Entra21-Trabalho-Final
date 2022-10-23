using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Guards
{
    public interface IGuardEntityMapping
    {
        Guard RegisterWith(GuardRegisterViewModel viewModel);
        Guard UpdateWith(Guard guard, GuardUpdateViewModel viewModel);
    }
}