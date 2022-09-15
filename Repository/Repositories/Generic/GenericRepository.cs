using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;

namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public abstract class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ShortTermParkingContext _context;

        public GenericRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null)
                return false;

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

            return true;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public TEntity? GetById(int id) =>
            _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);

        public IList<TEntity> GetAll() =>
            _context.Set<TEntity>().ToList();

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
