namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Payment : EntityBase
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public string PayerId { get; set; }
        public string TransactionId { get; set; }
        public decimal Value { get; set; }
        public Vehicle Vehicle { get; set; }
        public int? VehicleId { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
