using Entra21.CSharp.Area21.Repository.Authentication;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;
using Entra21.CSharp.Area21.RepositoryDataBase;

namespace Entra21.CSharp.Area21.Repository.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ShortTermParkingContext _context;

        public UserRepository(ShortTermParkingContext context) : base(context)
        {
            _context = context;
        }

        public User? GetByEmailAndPassword(string email, string password) =>
            _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password.GetHash() && x.Status == true && x.IsEmailConfirmed == true);

        public IList<User>? GetActiveUsers() =>
            _context.Users.Where(x => x.Status == true && x.IsEmailConfirmed == true).ToList();

        public User? GetByCpf(string cpf) => _context.Users
            .FirstOrDefault(x => x.Cpf == cpf);
    }
}