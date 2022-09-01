using Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Guards
{
    public interface IGuardRepository
    {
        Guard Insert(Guard guard);
        void Update(Guard guard);
        bool Delete(int id);
        Guard? GetById(int id);
        IList<Guard> GetAll();

    }
}