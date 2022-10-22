using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles
{
    public class VehicleEntityMapping : IVehicleEntityMapping //TODO VehicleEntityMapping completar
    {
        public Vehicle RegisterWith(VehicleRegisterViewModel viewModel) =>
            new Vehicle
            {
                LicensePlate = viewModel.LicensePlate.Trim().ToUpper(),
                Model = viewModel.Model,
                Type  = (VehicleType)viewModel.Type,
                UserId = viewModel.UserId,
                CreatedAt = DateTime.Now
            };

        public Vehicle UpdateWith(Vehicle vehicle, VehicleUpdateViewModel viewModel)
        {
            vehicle.LicensePlate = viewModel.LicensePlate.Trim().ToUpper();
            vehicle.Model = viewModel.Model;
            vehicle.Type = (VehicleType)viewModel.Type;
            //vehicle.UserId = viewModel.UserId;
            vehicle.UpdatedAt = DateTime.Now;

            return vehicle;
        }
    }
}
