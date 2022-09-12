namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T entity);
        bool Delete(int id);
        void Update(T entity);
    }
}