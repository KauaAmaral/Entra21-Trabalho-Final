using Entra21.CSharp.Area21.Repository.Entities;
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
            var viewModel = new VehicleRegisterViewModel
            {
                LicensePlate = "MFW7995",
                Model = "Ford KA",
                Type = Entra21.CSharp.Area21.Repository.Enums.VehicleType.Carro,
                UserId = 2,
            };

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
            var vehicle = new Vehicle
            {
                LicensePlate = "AXJ0F45",
                Model = "Ford Focus",
                Type = Entra21.CSharp.Area21.Repository.Enums.VehicleType.Carro,
            };
        }
    }
}
