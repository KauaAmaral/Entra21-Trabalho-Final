using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;

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
                TokenExpiredDate = DateTime.Now.AddHours(1),
                Email = "efraim@gmail.com",
                Password = "12345678",
                Cpf = "123.456.789-10",
                Hierarchy = Entra21.CSharp.Area21.Repository.Enums.UserHierarchy.Administrador,                
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
    }
}