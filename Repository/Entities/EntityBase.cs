namespace Entra21.CSharp.Area21.Repository.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
