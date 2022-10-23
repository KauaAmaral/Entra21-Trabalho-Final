using Entra21.CSharp.Area21.Repository.Authentication;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
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
        public void Test_Disable()
        {
            // Arrange
            var userChange = new User
            {
                Id = 5,
                Name = "Leonardo Salvador",
                Cpf = "101.147.854.33",
                Status = true
            };        

            // Act
            _userService.Disable(userChange);

            // Assert
            _userRepository.Update(userChange);
        }

        [Fact]
        public void Test_Register()
        {
            // Arrange
            var viewModel = new UserRegisterViewModel
            {
                Name = "Luiz Roberto",
                Cpf = "198.445.012-45",
                Email = "luiz-roberto@gmail.com",
                Token = Guid.NewGuid(),
                Password = "154d612",
            };

            var user = new User()
            {
                Name = viewModel.Name,
                Cpf = viewModel.Cpf,
                Email = viewModel.Email,
                Token = viewModel.Token,
                Password = viewModel.Password
            };

            _userEntityMapping.RegisterWith(Arg.Is<UserRegisterViewModel>
                (x => x.Name == viewModel.Name &&
                    x.Cpf == viewModel.Cpf &&
                    x.Email == viewModel.Email &&
                    x.Token == viewModel.Token &&
                    x.Password == viewModel.Password))
                .Returns(user);

            // Act
            _userService.Insert(viewModel);

            // Assert
            _userRepository.Received(1).Add(Arg.Is<User>(
                user => ValidateUser(user, viewModel)));
        }

        [Fact]
        public void Test_RegisterAdministrator()
        {
            // Arrange
            var viewModel = new UserRegisterViewModel
            {
                Name = "Luiz Roberto",
                Cpf = "198.445.012-45",
                Email = "luiz-roberto@gmail.com",
                Token = Guid.NewGuid(),
                Password = "154d612"
            };

            var user = new User()
            {
                Name = viewModel.Name,
                Cpf = viewModel.Cpf,
                Email = viewModel.Email,
                Token = viewModel.Token,
                Password = viewModel.Password
            };

            _userEntityMapping.RegisterWith(Arg.Is<UserRegisterViewModel>
                (x => x.Name == viewModel.Name &&
                    x.Cpf == viewModel.Cpf &&
                    x.Email == viewModel.Email &&
                    x.Token == viewModel.Token &&
                    x.Password == viewModel.Password))
                .Returns(user);

            // Act
            _userService.InsertAdministrator(viewModel);

            // Assert
            _userRepository.Received(1).Add(Arg.Is<User>(
                user => ValidateUser(user, viewModel)));
        }

        [Fact]
        public void Test_Update_With_User_Found()
        {
            // Arrange
            var viewModel = new UserUpdateViewModel
            {
                Id = 3,
                Name = "Miguel Pereira",
                Cpf = "198.445.012-45",
                Email = "miguel_pereira@gmail.com",
                Phone = "47988452610"
            };

            var userToEdit = new User
            {
                Id = 3,
                Name = "Miguel Ferreira",
                Cpf = "198.445.012-44",
                Email = "miguel-ferreira@gmail.com",
                Phone = "47991206630"
            };

            _userEntityMapping.UpdateWith(
                Arg.Is<User>(x => x.Id == userToEdit.Id &&
                    x.Name == userToEdit.Name && 
                    x.Cpf == userToEdit.Cpf &&
                    x.Email == userToEdit.Email &&
                    x.Phone == userToEdit.Phone),
                Arg.Is<UserUpdateViewModel>(x => x.Id == viewModel.Id &&
                    x.Name == viewModel.Name &&
                    x.Cpf == viewModel.Cpf &&
                    x.Email == viewModel.Email &&
                    x.Phone == viewModel.Phone))
                .Returns(userToEdit);

            _userRepository.GetById(Arg.Is(viewModel.Id)).Returns(userToEdit);

            // Act
            _userService.Update(viewModel);

            // Assert
            _userRepository.Received(1).Update(Arg.Is<User>(user =>
                ValidateUserWithUserUpdateViewModel(user, userToEdit)));
        }

        [Fact]
        public void Test_Update_With_User_Not_Found()
        {
            // Arrange
            var viewModel = new UserUpdateViewModel
            {
                Id = 5,
                Name = "Fernando Coelho",
                Cpf = "101.477.012-03",
                Email = "fcoelho@outlook.com",
                Phone = "47999856336"
            };

            _userRepository.GetById(Arg.Is(viewModel.Id)).ReturnsNull();

            // Act
            _userService.Update(viewModel);

            // Assert
            _userRepository
                .DidNotReceive()
                .Update(Arg.Any<User>());
        }

        [Fact]
        public void Test_UpdateAdministrator()
        {
            // Arrange
            var viewModel = new UserUpdateAdministratorViewModel
            {
                Id = 11,
                Name = "Claudio Raimundo",
                Cpf = "023.115.003-45",
                Email = "claudioraimundo@gmail.com",
                Phone = "47991206630",
                Password = "1a2b3c4d".GetHash(),
                HierarchyId = UserHierarchy.Motorista
            };

            var userToEdit = new User
            {
                Id = 11,
                Name = "Claudio Raimundo",
                Cpf = "023.115.003-45",
                Email = "claudioraimundo@gmail.com",
                Phone = "47991206630",
                Password = "1234ABCD".GetHash(),
                Hierarchy = UserHierarchy.Guarda
            };

            _userEntityMapping.UpdateWithAdministrator(
                Arg.Is<User>(x => x.Id == userToEdit.Id &&
                    x.Name == userToEdit.Name &&
                    x.Cpf == userToEdit.Cpf &&
                    x.Email == userToEdit.Email &&
                    x.Phone == userToEdit.Phone &&
                    x.Password == userToEdit.Password &&
                    x.Hierarchy == userToEdit.Hierarchy),
                Arg.Is<UserUpdateAdministratorViewModel>(x => x.Id == viewModel.Id &&
                    x.Name == viewModel.Name &&
                    x.Cpf == viewModel.Cpf &&
                    x.Email == viewModel.Email &&
                    x.Phone == viewModel.Phone &&
                    x.Password == viewModel.Password &&
                    x.HierarchyId == viewModel.HierarchyId))
                .Returns(userToEdit);

            _userRepository.GetById(Arg.Is(viewModel.Id)).Returns(userToEdit);

            // Act
            _userService.UpdateAdministrator(viewModel);

            // Assert
            _userRepository.Received(1).Update(Arg.Is<User>(user =>
                ValidateUserWithUserAdministratorUpdateViewModel(user, userToEdit)));
        }

        [Fact]
        public void Test_GetByCpf()
        {
            // Arrange
            var cpf = "123.456.789-10";

            var user = new User
            {
                Cpf = cpf
            };

            _userRepository.GetByCpf(cpf)
                .Returns(user);

            // Act
            var userCpf = _userService.GetByCpf(cpf);

            // Assert
            userCpf.Cpf.Should().Be(user.Cpf);
        }

        [Fact]
        public void Test_GetById_With_User_Found()
        {
            // Arrange
            var id = 3;

            var expectedUser = new User
            {
                Id = 3,
                Name = "Miguel Coelho",
                Cpf = "101.477.012-03",
                Email = "miguelcoelho@outlook.com",
            };

            _userRepository.GetById(Arg.Is(id))
                .Returns(expectedUser);

            // Act
            var user = _userService.GetById(id);

            // Assert
            user.Name.Should().Be(expectedUser.Name);
            user.Cpf.Should().Be(expectedUser.Cpf);
            user.Email.Should().Be(expectedUser.Email);
        }

        [Fact]
        public void Test_GetById_With_User_Not_Found()
        {
            // Arrange
            var id = 15;

            _userRepository.GetById(Arg.Is(15)).ReturnsNull();

            // Act
            var user = _userService.GetById(id);

            // Assert
            user.Should().BeNull();

            _userRepository.Received(1).GetById(Arg.Is(15));
        }

        [Fact]
        public void Test_UpdatePassword()
        {
            // Arrange
            var passwordToEdit = new User

            {
                Password = "12345678"
            };

            var viewModel = new UserChangePasswordViewModel
            {
                CurrentPassword = passwordToEdit.Password,
                NewPassword = "ABCDEFGH",
                ConfirmNewPassword = "ABCDEFGH"
            };


            _userEntityMapping.UpdatePasswordWith(
                Arg.Is<User>(x => x.Password == passwordToEdit.Password),
                Arg.Is<UserChangePasswordViewModel>(x => x.CurrentPassword == passwordToEdit.Password))
                .Returns(passwordToEdit);

            _userRepository.GetById(Arg.Is(viewModel.Id)).Returns(passwordToEdit);

            // Act
            _userService.UpdatePassword(viewModel);

            // Assert
            _userRepository.Received(1).Update(Arg.Is<User>(user =>
                ValidateUserWithUserChangePasswordViewModel(user, passwordToEdit)));
        }

        private bool ValidateUser(User user, UserRegisterViewModel viewModel)
        {
            user.Name.Should().Be(viewModel.Name);
            user.Email.Should().Be(viewModel.Email);

            return true;
        }

        private bool ValidateUserWithUserUpdateViewModel(
           User user, User userExpected)
        {
            user.Id.Should().Be(userExpected.Id);
            user.Name.Should().Be(userExpected.Name);
            user.Cpf.Should().Be(userExpected.Cpf);
            user.Email.Should().Be(userExpected.Email);
            user.Phone.Should().Be(userExpected.Phone);

            return true;
        }

        private bool ValidateUserWithUserAdministratorUpdateViewModel(
           User user, User userExpected)
        {
            user.Id.Should().Be(userExpected.Id);
            user.Name.Should().Be(userExpected.Name);
            user.Cpf.Should().Be(userExpected.Cpf);
            user.Email.Should().Be(userExpected.Email);
            user.Phone.Should().Be(userExpected.Phone);
            user.Password.Should().Be(userExpected.Password);
            user.Hierarchy.Should().Be(userExpected.Hierarchy);

            return true;
        }

        private bool ValidateUserWithUserChangePasswordViewModel(
            User user, User passwordExpected)
        {
            user.Password.Should().Be(passwordExpected.Password);

            return true;
        }
    }
}