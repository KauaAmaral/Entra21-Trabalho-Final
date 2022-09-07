using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.Area21.Service.Services.Vehicles
{
    internal class VehicleService
    {
        private readonly IVehicleRepository _vehicleRepostiry;
        private readonly IVehicleEntityMapping _vehicleEntityMapping;
    }
}
