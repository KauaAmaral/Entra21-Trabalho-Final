using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Guards;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Tests.Unit.Service.Services
{
    public class GuardServiceTests
    {
        private readonly IGuardService _guardService;
        private readonly IGuardRepository _guardRepository;
        private readonly IGuardEntityMapping _guardEntityMapping;

        public GuardServiceTests()
        {
            _guardRepository = Substitute.For<IGuardRepository>();
            _guardEntityMapping = Substitute.For<IGuardEntityMapping>();
            _guardService = new GuardService(_guardRepository, _guardEntityMapping);
        }

        [Fact]
        public void Test_Delete()
        {
            // Arrange
            var id = 2;

            // Act
            _guardService.Delete(id);

            // Assert
            _guardRepository
                .Received()
                .Delete(Arg.Is(2));
        }

        [Fact]
        public void Test_Register()
        {
            // Arrange
            var viewModel = new GuardRegisterViewModel
            {  
                IdentificationNumber = "1234567890",
                UserId = 2
            };

            var guard = new Guard()
            {
                IdentificationNumber = viewModel.IdentificationNumber,
                UserId = viewModel.UserId.Value
            };

            _guardEntityMapping.RegisterWith(Arg.Is<GuardRegisterViewModel>(
                x => x.IdentificationNumber == viewModel.IdentificationNumber &&
                    x.UserId == viewModel.UserId))
                .Returns(guard);

            // Act            
            _guardService.Register(viewModel);

            // Assert
            _guardRepository.Received(1).Add(Arg.Is<Guard>(
                guard => ValidateGuard(guard, viewModel)));
        }

        [Fact]
        public void Test_Update_With_Guard_Found()
        {
            // Arrange
            var viewModel = new GuardUpdateViewModel
            {
                Id = 3,
                IdentificationNumber = "2145612179",
                UserId = 9
            };

            var guardToEdit = new Guard
            {
                Id = 3,
                IdentificationNumber = "2145620178",
                UserId = 9
            };

            _guardEntityMapping.UpdateWith(
                Arg.Is<Guard>(x => x.Id == guardToEdit.Id &&
                    x.IdentificationNumber == guardToEdit.IdentificationNumber &&
                    x.UserId == guardToEdit.UserId),
                Arg.Is<GuardUpdateViewModel>(x => x.Id == viewModel.Id &&
                    x.IdentificationNumber == viewModel.IdentificationNumber &&
                    x.UserId == viewModel.UserId))
                .Returns(guardToEdit);

            _guardRepository.GetById(Arg.Is(viewModel.Id)).Returns(guardToEdit);

            // Act
            _guardService.Update(viewModel);

            // Assert
            _guardRepository.Received(1).Update(Arg.Is<Guard>(guard =>
                ValidateGuardWithGuardUpdateViewModel(guard, guardToEdit)));
        }

        [Fact]
        public void Test_Update_With_Guard_Not_Found()
        {
            // Arrange
            var viewModel = new GuardUpdateViewModel
            {
                Id = 7,
                IdentificationNumber = "4571115412",
                UserId = 14
            };

            _guardRepository.GetById(Arg.Is(viewModel.Id)).ReturnsNull();

            // Act
            _guardService.Update(viewModel);

            // Assert
            _guardRepository
                .DidNotReceive()
                .Update(Arg.Any<Guard>());
        }

        [Fact]
        public void Test_GetById_With_Guard_Found()
        {
            // Arrange
            var id = 5;

            var expectedGuard = new Guard
            {
                Id = id,
                IdentificationNumber = "1234567890",
            };

            _guardRepository.GetById(Arg.Is(id))
                .Returns(expectedGuard);

            // Act
            var guard = _guardService.GetById(id);

            // Assert
            guard.IdentificationNumber.Should().Be(expectedGuard.IdentificationNumber);
        }

        [Fact]
        public void Test_GetById_With_Guard_Not_Found()
        {
            // Arrange
            var id = 25;

            _guardRepository.GetById(Arg.Is(25)).ReturnsNull();

            // Act
            var guard = _guardService.GetById(id);

            // Assert
            guard.Should().BeNull();

            _guardRepository.Received(1).GetById(Arg.Is(25));
        }

        private bool ValidateGuard(Guard guard, GuardRegisterViewModel viewModel)
        {
            guard.IdentificationNumber.Should().Be(viewModel.IdentificationNumber);
            guard.UserId.Should().Be(viewModel.UserId);

            return true;
        }

        private bool ValidateGuardWithGuardUpdateViewModel(
            Guard guard, Guard guardExpected)
        {
            guard.Id.Should().Be(guardExpected.Id);
            guard.IdentificationNumber.Should().Be(guardExpected.IdentificationNumber);
            guard.UserId.Should().Be(guardExpected.UserId);

            return true;
        }
    }
}