using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;

namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public abstract class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : EntityBase
    {
        private readonly ShortTermParkingContext _context;

        public GenericRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public virtual T Create(T entity) 
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
