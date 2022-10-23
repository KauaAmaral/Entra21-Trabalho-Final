using Entra21.CSharp.Area21.Repository.Enums;

namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class User : EntityBase
    {
        public Guid Token { get; set; }
        public DateTime TokenExpiredDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string? Phone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public UserHierarchy Hierarchy { get; set; } 

        public IList<Payment> Payments { get; set; }
        public IList<Vehicle> Vehicles { get; set; }
        public IList<Guard> Guards { get; set; }
    }
}