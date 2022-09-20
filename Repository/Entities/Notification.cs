namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Notification : EntityBase
    {
        public bool RegisteredVehicle { get; set; }
        public string Address { get; set; }
        public string VehiclePlate { get; set; }
        public string Comments { get; set; }

        public int GuardId { get; set; }
        public Guard Guard { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}