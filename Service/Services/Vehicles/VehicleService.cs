using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;

namespace Entra21.CSharp.Area21.Service.Services.Vehicles
{
    public class VehicleService : IVehicleService
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

        public IList<Vehicle> GetByUserId(int userId) =>
            _vehicleRepository.GetByUserId(userId);

        public Vehicle? GetByVehiclePlate(string vehiclePlate)
        {
            var vehicle = _vehicleRepository.GetByVehiclePlate(vehiclePlate);

            return vehicle;
        }

        public IList<VehicleIndexViewModel> GetAll()
        {
            var vehicles = _vehicleRepository.GetAll();

            return vehicles.Select(x => new VehicleIndexViewModel
            {
                Id = x.Id,
                Name = x.User.Name,
                Model = x.Model,
                LicensePlate = x.LicensePlate,
                Type = x.Type
            }).ToList();
        }

        public VehicleUpdateViewModel? GetViewModelById(int id)
        {
            var vehicle = _vehicleRepository.GetById(id);

            var vehicleUpdateViewMode = new VehicleUpdateViewModel
            {
                Id = vehicle.Id,
                LicensePlate = vehicle.LicensePlate,
                Model = vehicle.Model,
                Type = vehicle.Type,
                TypeName = Enum.GetName(typeof(VehicleType), vehicle.Type)?.ToString() ?? string.Empty
            };
            return vehicleUpdateViewMode;
        }
    }
}