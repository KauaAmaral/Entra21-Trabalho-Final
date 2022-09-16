namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        bool Delete(int id);
        void Update(TEntity entity);
        TEntity? GetById(int id);
        IList<TEntity> GetAll();
    }
}