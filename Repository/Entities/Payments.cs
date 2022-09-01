namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Payment : EntityBase
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
