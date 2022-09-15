using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Guards
{
    public class GuardEntityMapping : IGuardEntityMapping
    {
        public Guard RegisterWith(GuardRegisterViewModel viewModel) =>
            new Guard
            {
                UserId = viewModel.UserId.GetValueOrDefault(),
                CreatedAt = DateTime.Now
            };
    }
}
