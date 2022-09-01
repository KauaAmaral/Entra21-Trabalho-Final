using Entra21.CSharp.Area21.Repository.Entities;

namespace Repository.Entities
{
    public class Guard : EntityBase
    {
        public User User { get; set; }  
        public string IdentificationNumber { get; set; }
    }
}
