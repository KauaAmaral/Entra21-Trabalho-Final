namespace Entra21.CSharp.Area21.RepositoryEntities
{
    public abstract class EntitieBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
