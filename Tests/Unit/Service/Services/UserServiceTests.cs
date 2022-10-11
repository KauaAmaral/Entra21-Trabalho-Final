using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using FluentAssertions;
using NSubstitute;
using System.Data.Entity.Hierarchy;
using Xunit;

namespace Tests.Unit.Service.Services
{
    public class UserServiceTests
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly IUserEntityMapping _userEntityMapping;

        public UserServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _userEntityMapping = Substitute.For<IUserEntityMapping>();
            _userService = new UserService(_userRepository, _userEntityMapping);
        }

        [Fact]
        public void Test_Delete()
        {
            // Arrange
            var id = 2;

            // Act
            _userService.Delete(id);

            // Assert
            _userRepository
                .Received()
                .Delete(Arg.Is(2));
        }

        [Fact]
        public void Test_Register()
        {
            // Arrange
            var user = new User();

            var viewModel = new UserRegisterViewModel
            {
                Name = "Luiz Roberto",
                Cpf = "198.445.012-45",
                Email = "luiz-roberto@gmail.com",
                Hierarchy = UserHierarchy.Administrador
            };

            // Act
            _userService.Insert(viewModel);

            // Assert
            _userRepository.Received(1).Add(Arg.Is<User>(
                user => ValidateUser(user, viewModel)));
        }
            private bool ValidateUser(User user, UserRegisterViewModel viewModel)
            {
                user.Name.Should().Be(viewModel.Name);
                user.Cpf.Should().Be(viewModel.Cpf);
                user.Email.Should().Be(viewModel.Email);
                user.Hierarchy.Should().Be(viewModel.Hierarchy);

                return true;
            }

    }
}
