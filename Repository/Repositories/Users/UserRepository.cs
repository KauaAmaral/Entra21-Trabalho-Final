﻿using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;

namespace Entra21.CSharp.Area21.Repository.Repositories.Users
{
    internal class UserRepository : IUserRepository
    {
        public readonly ShortTermParkingContext _context;

        public UserRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public bool Apagar(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();

            return true;
        }

        public User Cadastrar(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Editar(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public User? ObterPorId(int id) =>
            _context.Users.FirstOrDefault(x => x.Id == id);

        public IList<User> ObterTodos() =>
            _context.Users.ToList();
    }
}
