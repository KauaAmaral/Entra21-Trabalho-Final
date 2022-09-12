using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Vehicles
{
    public interface IVehicleRepository
    {
        Vehicle Insert(Vehicle vehicles);
        void Update(Vehicle vehicle);
        bool Delete(int id);
        Vehicle? GetById(int id);
        IList<Vehicle> GetAll(int id);
    }
}
