using Entra21.CSharp.Area21.Repository.Enums;

namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Notification : EntityBase
    {
        public string Address { get; set; }
        public string? Comments { get; set; }
        public string VehicleLicensePlate { get; set; }
        public bool RegisteredVehicle { get; set; }
        public VehicleType Type { get; set; } 
        public int NotificationAmount { get; set;} 

        public string? Token { get; set; }
        public string? PayerId { get; set; }
        public string? TransactionId { get; set; }
        public decimal? Value { get; set; }

        public int GuardId { get; set; }
        public Guard Guard { get; set; }

        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}