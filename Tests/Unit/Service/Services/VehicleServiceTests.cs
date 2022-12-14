using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Tests.Unit.Service.Services
{
    public class VehicleServiceTests
    {
        private readonly IVehicleService _vehicleService;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleEntityMapping _vehicleEntityMapping;

        public VehicleServiceTests()
        {
            _vehicleRepository = Substitute.For<IVehicleRepository>();
            _vehicleEntityMapping = Substitute.For<IVehicleEntityMapping>();
            _vehicleService = new VehicleService(_vehicleRepository, _vehicleEntityMapping);
        }

        [Fact]
        public void Test_Delete()
        {
            // Arrange
            var id = 4;

            // Act
            _vehicleService.Delete(id);

            // Assert
            _vehicleRepository
                .Received()
                .Delete(Arg.Is(4));
        }

        [Fact]
        public void Test_Register()
        {
            // Arrange            
            var viewModel = new VehicleRegisterViewModel
            {
                LicensePlate = "MRA7745",
                Model = "Fiat Uno",
                Type = VehicleType.Carro,
                UserId = 5
            };

            var vehicle = new Vehicle()
            {
                LicensePlate = viewModel.LicensePlate,
                Model = viewModel.Model,
                Type = viewModel.Type,
                UserId = viewModel.UserId
            };

            _vehicleEntityMapping.RegisterWith(Arg.Is<VehicleRegisterViewModel>(
                x => x.LicensePlate == viewModel.LicensePlate &&
                    x.Model == viewModel.Model &&
                    x.Type == viewModel.Type &&
                    x.UserId == viewModel.UserId))
                .Returns(vehicle);

            // Act
            _vehicleService.Register(viewModel);

            // Assert
            _vehicleRepository.Received(1).Add(Arg.Is<Vehicle>(
                vehicle => ValidateVehicle(vehicle, viewModel)));
        }

        [Fact]
        public void Test_Update_With_Vehicle_Found()
        {
            // Arrange
            var viewModel = new VehicleUpdateViewModel
            {
                Id = 4,
                LicensePlate = "MRA7745",
                Model = "Fiat Uno",
                Type = VehicleType.Carro,
                UserId = 5
            };

            var vehicleToEdit = new Vehicle
            {
                Id = 4,
                LicensePlate = "MSA7J00",
                Model = "Honda CG 125",
                Type = VehicleType.Moto,
                UserId = 7
            };

            _vehicleEntityMapping.UpdateWith(
                Arg.Is<Vehicle>(x => x.Id == viewModel.Id &&
                    x.LicensePlate == vehicleToEdit.LicensePlate &&
                    x.Model == vehicleToEdit.Model &&
                    x.Type == vehicleToEdit.Type &&
                    x.UserId == vehicleToEdit.UserId),
                Arg.Is<VehicleUpdateViewModel>(x => x.Id == viewModel.Id &&
                    x.LicensePlate == viewModel.LicensePlate &&
                    x.Model == viewModel.Model &&
                    x.Type == viewModel.Type &&
                    x.UserId == viewModel.UserId))                   
                .Returns(vehicleToEdit);

            _vehicleRepository.GetById(Arg.Is(viewModel.Id)).Returns(vehicleToEdit);

            // Act
            _vehicleService.Update(viewModel);

            // Assert
            _vehicleRepository.Received(1).Update(Arg.Is<Vehicle>(vehicle =>
                ValidateVehicleWithVehicleUpdateViewModel(vehicle, vehicleToEdit)));
        }

        [Fact]
        public void Test_Update_With_Vehicle_Not_Found()
        {
            // Arrange
            var viewModel = new VehicleUpdateViewModel
            {
                Id = 4,
                LicensePlate = "MRA7K45",
                Model = "Fiat Mobi",
                Type = VehicleType.Carro,
                UserId = 5
            };

            _vehicleRepository.GetById(Arg.Is(viewModel.Id)).ReturnsNull();

            // Act
            _vehicleService.Update(viewModel);

            // Assert
            _vehicleRepository
                .DidNotReceive()
                .Update(Arg.Any<Vehicle>());
        }

        [Fact]
        public void Test_GetByVehiclePlate()
        {
            // Arrange
            var vehiclePlate = "DBW1A22";

            var vehicle = new Vehicle
            {
                LicensePlate = vehiclePlate,
            };

            _vehicleRepository.GetByVehiclePlate(vehiclePlate)
                .Returns(vehicle);

            // Act
            var vehicleLicensePlate = _vehicleService.GetByVehiclePlate(vehiclePlate);

            // Assert
            vehicleLicensePlate.LicensePlate.Should().Be(vehicle.LicensePlate);
        }

        [Fact]
        public void Test_GetById_With_Vehicle_Found()
        {
            // Arrange
            var id = 5;

            var expectedVehicle = new Vehicle
            {
                Id = id,
                LicensePlate = "WRX0746",
                Model = "Honda Civic",
                Type = VehicleType.Carro,
                UserId = 5
            };

            _vehicleRepository.GetById(Arg.Is(id))
                .Returns(expectedVehicle);

            // Act
            var vehicle = _vehicleService.GetById(id);

            // Assert
            vehicle.LicensePlate.Should().Be(expectedVehicle.LicensePlate);
            vehicle.Model.Should().Be(expectedVehicle.Model);
            vehicle.Type.Should().Be(expectedVehicle.Type);
            vehicle.UserId.Should().Be(expectedVehicle.UserId);
        }

        [Fact]
        public void Test_GetById_With_Vehicle_Not_Found()
        {
            // Arrange
            var id = 25;

            _vehicleRepository.GetById(Arg.Is(25)).ReturnsNull();

            // Act
            var guard = _vehicleService.GetById(id);

            // Assert
            guard.Should().BeNull();

            _vehicleRepository.Received(1).GetById(Arg.Is(25));
        }

        private bool ValidateVehicle(Vehicle vehicle, VehicleRegisterViewModel viewModel)
        {
            vehicle.LicensePlate.Should().Be(viewModel.LicensePlate);
            vehicle.Model.Should().Be(viewModel.Model);
            vehicle.Type.Should().Be(viewModel.Type);
            vehicle.UserId.Should().Be(viewModel.UserId);

            return true;
        }

        private bool ValidateVehicleWithVehicleUpdateViewModel(
            Vehicle vehicle, Vehicle vehicleExpected)
        {
            vehicle.Id.Should().Be(vehicleExpected.Id);
            vehicle.LicensePlate.Should().Be(vehicleExpected.LicensePlate);
            vehicle.Model.Should().Be(vehicleExpected.Model);
            vehicle.Type.Should().Be(vehicleExpected.Type);
            vehicle.UserId.Should().Be(vehicleExpected.UserId);

            return true;
        }
    }
}