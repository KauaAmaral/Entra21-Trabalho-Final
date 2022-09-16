using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

namespace Entra21.CSharp.Area21.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserEntityMapping _userEntityMapping;

        public UserService(IUserRepository userRepository, IUserEntityMapping userEntityMapping)
        {
            _userRepository = userRepository;
            _userEntityMapping = userEntityMapping;
        }

        public bool Delete(int id) => 
            _userRepository.Delete(id);

        public bool VerifyEmails(string email)
        {
            if (_userRepository.GetActiveUsers().Where(x => x.Email == email).ToList().Count > 0)
                return false;

            return true;    
        }

        public IList<User> GetAll() =>
            _userRepository.GetAll();

        public User? GetByEmailAndPassword(string email, string password)
        {
            var user = _userRepository.GetByEmailAndPassword(email, password);

            return user;
        }

        public User? GetById(int id) => 
            _userRepository.GetById(id);

        public User Insert(UserRegisterViewModel viewModel)
        {
            var user = _userEntityMapping.RegisterWith(viewModel);

            _userRepository.Add(user);

            return user;
        }

        public bool Update(UserUpdateViewModel viewModel)
        {
            var user = _userRepository.GetById(viewModel.Id);

            if (user == null)
                return false;

            user = _userEntityMapping.UpdateWith(user, viewModel);

            _userRepository.Update(user);

            return true;
        }

        public bool UpdatePassword(UserChangePasswordViewModel viewModel)
        {
            var user = _userRepository.GetById(viewModel.Id);

            if (user == null)
                return false;

            user = _userEntityMapping.UpdatePasswordWith(user, viewModel);

            _userRepository.Update(user);

            return true;
        }

        public bool Disable(User userChange)
        {
            var user = _userRepository.GetById(userChange.Id);

            if (user == null)
                return false;

            user.Status = false;
            _userRepository.Update(user);

            return true;
        }

        public User UpdateVerifyEmail(int id)
        {
            var user = _userRepository.GetById(id);

            user.IsEmailConfirmed = true;
            user.Status = true;

            _userRepository.Update(user);

            return user;
        }
    }
}
