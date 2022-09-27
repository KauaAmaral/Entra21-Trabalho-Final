using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;

namespace Entra21.CSharp.Area21.Service.Services.Vehicles
{
    internal class VehicleService : IUserController
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleEntityMapping _vehicleEntityMapping;

        public VehicleService(
            IVehicleRepository vehicleRepostiry,
            IVehicleEntityMapping vehicleEntityMapping)
        {
            _vehicleRepository = vehicleRepostiry;
            _vehicleEntityMapping = vehicleEntityMapping;
        }

        public Vehicle Register(VehicleRegisterViewModel viewModel)
        {
            var vehicle = _vehicleEntityMapping.RegisterWith(viewModel);

            _vehicleRepository.Add(vehicle);

            return vehicle;
        }

        public bool Update(VehicleUpdateViewModel viewModel)
        {
            var vehicle = _vehicleRepository.GetById(viewModel.Id);

            if (vehicle == null)
                return false;

            _vehicleEntityMapping.UpdateWith(vehicle, viewModel);

            _vehicleRepository.Update(vehicle);

            return true;
        }

        public bool Delete(int id) =>
            _vehicleRepository.Delete(id);

        public Vehicle? GetById(int id) =>
            _vehicleRepository.GetById(id);

        public IList<Vehicle> GetAllById(int id) =>
            _vehicleRepository.GetAllById(id);       
    }
}
