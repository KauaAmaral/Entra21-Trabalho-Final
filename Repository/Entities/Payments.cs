namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class Payment : EntityBase
    {
        public Vehicle Auto { get; set; }
        public User User { get; set; }
    }
}
