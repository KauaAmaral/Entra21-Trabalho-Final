namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        bool Delete(int id);
        void Update(TEntity entity);
    }
}