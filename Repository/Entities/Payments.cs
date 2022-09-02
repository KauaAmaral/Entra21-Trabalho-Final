namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Payment : EntityBase
    {
        public User User { get; set; }
        public int UserId { get; set; }
     
        public Vehicle Vehicle { get; set; }
        public int? VehicleId { get; set; }
    }
}
