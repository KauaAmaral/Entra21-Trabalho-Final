using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.Area21.Repository.Repositories.Generic
{
    public abstract class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ShortTermParkingContext _context;

        public GenericRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public virtual TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);

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

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
