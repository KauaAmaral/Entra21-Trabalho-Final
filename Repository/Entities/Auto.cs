using Entra21.CSharp.Area21.RepositoryEnums;

namespace Entra21.CSharp.Area21.RepositoryEntities
{
    public class Auto : EntitieBase
    {
        public User User { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public ModelAuto ModelAuto { get; set; }
    }
}
