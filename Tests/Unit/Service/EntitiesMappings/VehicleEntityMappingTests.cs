using Bogus;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Service.EntitiesMappings
{
    public class VehicleEntityMappingTests
    {
        private readonly IVehicleEntityMapping _vehicleEntityMapping;
        public VehicleEntityMappingTests()
        {
            _vehicleEntityMapping = new VehicleEntityMapping();
        }

        [Fact]
        public void Test_RegisterWith()
        {
            // Arrange
            var viewModel = RegisterVehicle(VehicleType.Carro);
            
            // Act
            var vehicle = _vehicleEntityMapping.RegisterWith(viewModel);

            // Assert
            vehicle.LicensePlate.Should().Be(viewModel.LicensePlate);
            vehicle.Model.Should().Be(viewModel.Model);
            vehicle.Type.Should().Be(viewModel.Type);
            vehicle.UserId.Should().Be(viewModel.UserId);
        }

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange
            var vehicle = VehicleCreated(VehicleType.Carro);

            var viewModelEdit = UpdateVehicle(VehicleType.Moto);

            // Act
            _vehicleEntityMapping.UpdateWith(vehicle, viewModelEdit);

            // Assert
            vehicle.LicensePlate.Should().Be(viewModelEdit.LicensePlate);
            vehicle.Model.Should().Be(viewModelEdit.Model);
            vehicle.Type.Should().Be(viewModelEdit.Type);
        }

        private VehicleRegisterViewModel RegisterVehicle(VehicleType vehicleType)
            => new Faker<VehicleRegisterViewModel>()
            .RuleFor(x => x.LicensePlate, x => x.Random.Word())
            .RuleFor(x => x.Model, x => x.Random.Word())
            .RuleFor(x => x.Type, x => vehicleType)
            .RuleFor(x => x.UserId, x => x.Random.Number())
            .Generate();

        private Vehicle VehicleCreated(VehicleType vehicleType)
            => new Faker<Vehicle>()
            .RuleFor(x => x.LicensePlate, x => x.Random.Word())
            .RuleFor(x => x.Model, x => x.Random.Word())
            .RuleFor(x => x.Type, x => vehicleType)
            .Generate();

        private VehicleUpdateViewModel UpdateVehicle(VehicleType vehicleType)
            => new Faker<VehicleUpdateViewModel>()
            .RuleFor(x => x.LicensePlate, x => x.Random.Word())
            .RuleFor(x => x.Model, x => x.Random.Word())
            .RuleFor(x => x.Type, x => vehicleType)
            .Generate();
    }
}