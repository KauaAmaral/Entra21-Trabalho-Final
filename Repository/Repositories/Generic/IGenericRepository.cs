namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        T Insert(T entity);
        bool Delete(int id);
        void Update(T entity);
        T? GetById(int id);
        IList<T> GetAll();
    }
}