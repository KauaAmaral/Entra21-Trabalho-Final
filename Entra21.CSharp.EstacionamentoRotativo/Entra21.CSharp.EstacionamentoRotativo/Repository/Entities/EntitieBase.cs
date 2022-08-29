namespace Repository.Entities
{
    public abstract class EntitieBase
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime EditedTime { get; set; }
    }
}
