namespace Repository.Entities
{
    public class Guard : EntitieBase
    {
        public User User { get; set; }  
        public string IdentificationNumber { get; set; }
    }
}
