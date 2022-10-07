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

        public Guard GetById(int id)
        {
            var guard = _guardRepository.GetById(id);

            return guard;
        } 
        
        public Guard GetByUserId(int id)
        {
            var guard = _guardRepository.GetByUserId(id);

            return guard;
        }

        public Guard Register(GuardRegisterViewModel viewModel)
        {
            var guard = _guardEntityMapping.RegisterWith(viewModel);

            _guardRepository.Add(guard);

            return guard;
        }

        public bool Update(GuardUpdateViewModel viewModel)
        {
            var guard = _guardRepository.GetById(viewModel.Id);

            if (guard == null)
                return false;

            _guardEntityMapping.UpdateWith(guard, viewModel);

            _guardRepository.Update(guard);

            return true;
        }

        public void Delete(int id)
        {
            _guardRepository.Delete(id);
        }

        public Guard GetByIdUser(int id)
        {
            var guard = _guardRepository.GetByIdUser(id);

            return guard;
        }
    }
}