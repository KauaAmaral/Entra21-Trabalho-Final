using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.Services.Vehicles;

namespace Tests.Unit.Service.Services
{
    public class VehicleServiceTests
    {
        private readonly IVehicleService _vehicleService;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleEntityMapping _vehicleEntityMapping;
    }
}
