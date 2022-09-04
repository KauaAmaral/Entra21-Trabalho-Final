using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Guards
{
    public class GuardEntityMapping : IGuardEntityMapping
    {
        public Guard RegisterWith(GuardRegisterViewModel viewModel) =>
            new Guard
            {
                IdentificationNumber = viewModel.IdentificationNumber,
                UserId = viewModel.UserId.GetValueOrDefault(),
                CreatedAt = DateTime.Now
            };

        public void UpdateWith(Guard guard, GuardUpdateViewModel viewModel)
        {
            guard.IdentificationNumber = viewModel.IdentificationNumber;
            guard.UserId = viewModel.UserId.GetValueOrDefault();
            guard.UpdatedAt = DateTime.Now;
        }
    }
}
