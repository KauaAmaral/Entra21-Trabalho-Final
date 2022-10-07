using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;

namespace Entra21.CSharp.Area21.Repository.Repositories.Base
{
    public class RepositoryBase<TEntidade> : IRepositoryBase<TEntidade>
        where TEntidade : EntityBase
    {
        protected readonly ShortTermParkingContext _context;
        protected readonly DbSet<TEntidade> _dbSet;
        public RepositoryBase(ShortTermParkingContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntidade>();
        }

        public void Delete(int id)
        {
            var entidade = _dbSet.FirstOrDefault(x => x.Id == id);

            if (entidade == null)
                return;

            _dbSet.Remove(entidade);
            _context.SaveChanges(); 
        }

        public List<TEntidade> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntidade? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntidade Register(TEntidade entidade)
        {
            _dbSet.Add(entidade);

            _context.SaveChanges();

            return entidade;
        }

        public void Update(TEntidade entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }
    }
}
