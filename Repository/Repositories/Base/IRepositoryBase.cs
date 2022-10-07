using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Repository.Repositories.Base
{
    public interface IRepositoryBase<TEntidade>
        where TEntidade : EntityBase
    {
        TEntidade Register(TEntidade entidade);
        void Update(TEntidade entidade);
        void Delete(int id);
        List<TEntidade> GetAll();
        TEntidade? GetById(int id);
    }
}