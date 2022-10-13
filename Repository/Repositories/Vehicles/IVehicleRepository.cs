using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;

namespace Entra21.CSharp.Area21.Repository.Repositories.Vehicles
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        IList<Vehicle> GetByUserId(int userId);

        Vehicle? GetByVehiclePlate(string vehiclePlate);
    }
}
