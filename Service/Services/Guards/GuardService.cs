using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Guards;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.Services.Guards
{
    public class GuardService : IGuardService
    {
        private readonly IGuardRepository _guardRepository;
        private readonly IGuardEntityMapping _guardEntityMapping;

        public GuardService(
            IGuardRepository guardRepository,
            IGuardEntityMapping guardEntityMapping)
        {
            _guardRepository = guardRepository;
            _guardEntityMapping = guardEntityMapping;
        }

        public IList<Guard> GetAll() =>
            _guardRepository.GetAll();

        public Guard Register(GuardRegisterViewModel viewModel)
        {
            var guard = _guardEntityMapping.RegisterWith(viewModel);

            _guardRepository.Add(guard);

            return guard;
        }
    }
}
