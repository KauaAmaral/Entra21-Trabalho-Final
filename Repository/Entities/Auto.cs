using Entra21.CSharp.Area21.Repository.Enums;

namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Vehicle : EntityBase
    {
        public User User { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public VehicleType Type { get; set; }
    }
}
