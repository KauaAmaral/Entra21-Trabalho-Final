using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles
{
    public interface IVehicleEntityMapping
    {
        Vehicle RegisterWith(VehicleRegisterViewModel viewModel);
        Vehicle UpdateWith(Vehicle vehicle, VehicleUpdateViewModel viewModel);
    }
}