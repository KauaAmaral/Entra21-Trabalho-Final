using Bogus;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Service.EntitiesMappings
{
    public class GuardEntityMappingTests
    {
        private readonly IGuardEntityMapping _guardEntityMapping;
        public GuardEntityMappingTests()
        {
            _guardEntityMapping = new GuardEntityMapping();
        }

        [Fact]
        public void Test_RegisterWith()
        {
            // Arrange
            var viewModel = RegisterUser();

            // Act
            var guard = _guardEntityMapping.RegisterWith(viewModel);

            // Assert
            guard.IdentificationNumber.Should().Be(viewModel.IdentificationNumber);
            guard.UserId.Should().Be(viewModel.UserId);
        }

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange
            var guard = GuardCreated();

            var viewModelEdit = UpdateGuard();

            // Act
            _guardEntityMapping.UpdateWith(guard, viewModelEdit);

            // Assert
            guard.IdentificationNumber.Should().Be(viewModelEdit.IdentificationNumber);            
        }

        private GuardRegisterViewModel RegisterUser()
            => new Faker<GuardRegisterViewModel>()
            .RuleFor(x => x.IdentificationNumber, f => f.Random.Word())
            .RuleFor(x => x.UserId, f => f.Random.Number())
            .Generate();

        private Guard GuardCreated()
            => new Faker<Guard>()
            .RuleFor(x => x.IdentificationNumber, f => f.Random.Word())
            .RuleFor(x => x.UserId, f => f.Random.Number())
            .Generate();

        private GuardUpdateViewModel UpdateGuard()
            => new Faker<GuardUpdateViewModel>()
            .RuleFor(x => x.IdentificationNumber, f => f.Random.Word())
            .RuleFor(x => x.UserId, f => f.Random.Number())
            .Generate();
    }
}
