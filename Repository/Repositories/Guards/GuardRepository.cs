
﻿using Entra21.CSharp.Area21.Repository.Entities;
﻿using Entra21.CSharp.Area21.RepositoryDataBase;
using System.Data.Entity;

namespace Entra21.CSharp.Area21.Repository.Repositories.Guards
{
    public class GuardRepository : IGuardRepository
    {
        private readonly ShortTermParkingContext _context;

        public GuardRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var guard = _context.Guards.FirstOrDefault(x => x.Id == id);

            if (guard == null)
                return false;

            _context.Guards.Remove(guard);
            _context.SaveChanges();

            return true;
        }

        public Guard Insert(Guard guard)
        {
            _context.Guards.Add(guard);
            _context.SaveChanges();

            return guard;
        }

        public void Update(Guard guard)
        {
            _context.Guards.Update(guard);
            _context.SaveChanges();
        }

        public Guard? GetById(int id) =>
            _context.Guards
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        public IList<Guard> GetAll() =>
            _context.Guards
            .Include(x => x.User)
            .ToList();
    }
}