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

        public Guard UpdateWith(Guard guard, GuardUpdateViewModel viewModel)
        {
            guard.IdentificationNumber = viewModel.IdentificationNumber;
            guard.UpdatedAt = DateTime.Now;

            return guard;
        }
    }
}