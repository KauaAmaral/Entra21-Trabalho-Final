using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;

namespace Entra21.CSharp.Area21.Service.Services
{
    public class GuardService : IGuardService
    {
        private readonly IGuardService _guardService;
        private readonly IGuardEntityMapping _guardEntityMapping;

        public GuardService(
            GuardService guardService,
            GuardEntityMapping guardEntityMapping)
        {
            _guardService = guardService;
            _guardEntityMapping = guardEntityMapping;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Guard> GetAll()
        {
            throw new NotImplementedException();
        }

        public Guard? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Guard Register(GuardRegisterViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public bool Update(GuardUpdateViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
