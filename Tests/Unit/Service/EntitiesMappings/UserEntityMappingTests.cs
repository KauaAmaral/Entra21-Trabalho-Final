using Bogus;
using Entra21.CSharp.Area21.Repository.Authentication;
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
            var viewModel = RegisterUser(UserHierarchy.Administrador);

            // Act 
            var user = _userEntityMapping.RegisterWith(viewModel);

            // Assert
            user.Name.Should().Be(viewModel.Name);
            user.Token.Should().Be(viewModel.Token);
            user.TokenExpiredDate.Should().BeAfter(viewModel.TokenExpiredDate);
            user.TokenExpiredDate.Should().BeBefore(DateTime.Now.AddHours(2));
            user.Email.Should().Be(viewModel.Email);
            user.Password.Should().Be(viewModel.Password.GetHash());
            user.Cpf.Should().Be(viewModel.Cpf);
            user.Hierarchy.Should().Be(viewModel.Hierarchy);
        }    

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange
            var user = UserCreated();

            var viewModelEdit = UpdateUser();

            // Act
            _userEntityMapping.UpdateWith(user, viewModelEdit);

            // Assert            
            user.Name.Should().Be(viewModelEdit.Name);
            user.Cpf.Should().Be(viewModelEdit.Cpf);
            user.Email.Should().Be(viewModelEdit.Email);
            user.Phone.Should().Be(viewModelEdit.Phone);
        }

        [Fact]
        public void Test_UpdateWithAdministrator()
        {
            // Arrange
            var user = UserCreated();               
            
            var viewModelEdit = UpdateUserAdministrator(UserHierarchy.Guarda);

            // Act
            _userEntityMapping.UpdateWithAdministrator(user, viewModelEdit);

            // Assert          
            user.Name.Should().Be(viewModelEdit.Name);
            user.Cpf.Should().Be(viewModelEdit.Cpf);
            user.Email.Should().Be(viewModelEdit.Email);
            user.Phone.Should().Be(viewModelEdit.Phone);
            user.Hierarchy.Should().Be(viewModelEdit.HierarchyId);
        }

        [Fact]
        public void Test_UpdatePasswordWith()
        {
            // Arrange
            var faker = new Faker();

            var user = new User
            {
                Password = faker.Internet.Password()
            };

            var viewModelEdit = new UserChangePasswordViewModel
            {
                NewPassword = faker.Internet.Password()
            };

            // Act
            _userEntityMapping.UpdatePasswordWith(user, viewModelEdit);

            // Assert
            user.Password.Should().Be(viewModelEdit.NewPassword.GetHash());
        }

        private UserRegisterViewModel RegisterUser(UserHierarchy userHierarchy)
            => new Faker<UserRegisterViewModel>()
            .RuleFor(x => x.Name, f => f.Random.Word())
            .RuleFor(x => x.Token, f => f.Random.Guid())
            .RuleFor(x => x.TokenExpiredDate, f => DateTime.Now.AddHours(2))
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Password, f => f.Internet.Password())
            .RuleFor(x => x.Cpf, f => f.Random.Word())
            .RuleFor(x => x.Hierarchy, f => userHierarchy)
            .Generate();

        private User UserCreated()
            => new Faker<User>()
            .RuleFor(x => x.Name, f => f.Random.Word())
            .RuleFor(x => x.Cpf, f => f.Random.Word())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Phone, f => f.Random.Word())
            .Generate();

        private UserUpdateViewModel UpdateUser()
            => new Faker<UserUpdateViewModel>()
            .RuleFor(x => x.Name, f => f.Random.Word())
            .RuleFor(x => x.Cpf, f => f.Random.Word())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Phone, f => f.Random.Word())
            .Generate();

        private UserUpdateAdministratorViewModel UpdateUserAdministrator(UserHierarchy userHierarchy)
            => new Faker<UserUpdateAdministratorViewModel>()          
            .RuleFor(x => x.Name, f => f.Random.Word())
            .RuleFor(x => x.Cpf, f => f.Random.Word())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Phone, f => f.Random.Word())
            .RuleFor(x => x.HierarchyId, f => userHierarchy)
            .Generate();
    }
}