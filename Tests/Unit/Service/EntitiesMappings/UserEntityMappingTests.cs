using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Service.EntitiesMappings
{
    public class UserEntityMappingTests
    {
        private readonly IUserEntityMapping _userEntityMapping;
        public UserEntityMappingTests()
        {
            _userEntityMapping = new UserEntityMapping();
        }

        [Fact]
        public void Test_RegisterWith()
        {
            // Arrange
            var viewModel = new UserRegisterViewModel
            {
                Name = "Efraim Calebe",
                Token = Guid.Empty,
                TokenExpiredDate = DateTime.Now.AddHours(2),
                Email = "efraim@gmail.com",
                Password = "12345678",
                Cpf = "123.456.789-10",
                Hierarchy = UserHierarchy.Administrador,                
            };

            // Act 
            var user = _userEntityMapping.RegisterWith(viewModel);

            // Assert
            user.Name.Should().Be(viewModel.Name);
            user.Token.Should().Be(viewModel.Token);
            user.TokenExpiredDate.Should().Be(viewModel.TokenExpiredDate);
            user.Email.Should().Be(viewModel.Email);
            user.Password.Should().Be(viewModel.Password);
            user.Cpf.Should().Be(viewModel.Cpf);
            user.Hierarchy.Should().Be(viewModel.Hierarchy);
        }

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange
            var user = new User
            {
                Id = 11,
                Name = "Marcos José",
                Cpf = "127.451.478-72",
                Email = "marcos-jose@gmail.com",
                Phone = "48941456577"
            };

            var viewModelEdit = new UserUpdateViewModel
            {
                Id = 11,
                Name = "João Gustavo",
                Cpf = "121.454.122-78",
                Email = "joao.gustavo@gmail.com",
                Phone = "47991544963"
            };

            // Act
            _userEntityMapping.UpdateWith(user, viewModelEdit);

            // Assert
            user.Id.Should().Be(viewModelEdit.Id);
            user.Name.Should().Be(viewModelEdit.Name);
            user.Cpf.Should().Be(viewModelEdit.Cpf);
            user.Email.Should().Be(viewModelEdit.Email);
            user.Phone.Should().Be(viewModelEdit.Phone);
        }

        [Fact]
        public void Test_UpdateWithAdministrator()
        {
            // Arrange
            var user = new User
            {
                Id = 11,
                Name = "Marcos José",
                Cpf = "127.451.478-72",
                Email = "marcos-jose@gmail.com",
                Phone = "48941456577",
                Hierarchy = UserHierarchy.Motorista
            };

            var viewModelEdit = new UserUpdateAdministratorViewModel
            {
                Id = 11,
                Name = "João Gustavo",
                Cpf = "121.454.122-78",
                Email = "joao.gustavo@gmail.com",
                Phone = "47991544963",
                Hierarchy = UserHierarchy.Guarda
            };

            // Act
            _userEntityMapping.UpdateWithAdministrator(user, viewModelEdit);

            // Assert
            user.Id.Should().Be(viewModelEdit.Id);
            user.Name.Should().Be(viewModelEdit.Name);
            user.Cpf.Should().Be(viewModelEdit.Cpf);
            user.Email.Should().Be(viewModelEdit.Email);
            user.Phone.Should().Be(viewModelEdit.Phone);
            user.Hierarchy.Should().Be(viewModelEdit.Hierarchy);
        }

        [Fact]
        public void Test_UpdatePasswordWith()
        {
            // Arrange
            var user = new User
            {       
                Password = "ABCDE"
            };

            var viewModelEdit = new UserChangePasswordViewModel
            {
                NewPassword = "1234567890123456789012345678901234567890123456789012345678901234"
            };

            // Act
            _userEntityMapping.UpdatePasswordWith(user, viewModelEdit);

            // Assert
            user.Password.Should().Be(viewModelEdit.NewPassword);
        }
    }
}