using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles
{
    public class VehicleEntityMapping : IVehicleEntityMapping //TODO VehicleEntityMapping completar
    {
        public Vehicle RegisterWith(VehicleRegisterViewModel viewModel) =>
            new Vehicle
            {
                LicensePlate = viewModel.LicensePlate,
                UserId = viewModel.UserId.GetValueOrDefault(),
                CreatedAt = DateTime.Now
            };

        public void UpatedeWith(Vehicle vehicle, VehicleUpdateViewModel viewModel)
        {
            vehicle.LicensePlate = viewModel.LicensePlate;
            vehicle.UserId = viewModel.UserId.GetValueOrDefault();
            vehicle.UpdatedAt = DateTime.Now;
        }

    }
}
