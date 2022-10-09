using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.Services.Users;

namespace Tests.Unit.Service.Services
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserEntityMapping _userEntityMapping;
    }
}
