using Entra21.CSharp.Area21.Repository.Entities;

namespace Repository.Entities
{
    public class Guard : EntityBase
    {
        public string IdentificationNumber { get; set; }
        public User User { get; set; }  
        public int UserId { get; set; }

        //public IList<Notification> Notifications { get; set; }
    }
}
