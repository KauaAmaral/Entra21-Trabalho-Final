using Bogus;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Service.EntitiesMappings
{
    public class NotificationEntityMappingTests
    {
        private readonly INotificationEntityMapping _notificationEntityMapping;
        public NotificationEntityMappingTests()
        {
            _notificationEntityMapping = new NotificationEntityMapping();
        }

        [Fact]
        public void Test_RegisterWith()
        {
            // Arrange
            var viewModel = RegisterNotification();

            // Act
            var notification = _notificationEntityMapping.RegisterWith(viewModel);

            // Assert
            notification.GuardId.Should().Be(viewModel.GuardId);
            notification.VehicleId.Should().Be(viewModel.VehicleId);
            notification.VehicleLicensePlate.Should().Be(viewModel.VehiclePlate);
            notification.RegisteredVehicle.Should().Be(viewModel.Registered);
            notification.Comments.Should().Be(viewModel.Comments);
            notification.Address.Should().Be(viewModel.Address);
            notification.NotificationAmount.Should().Be(viewModel.NotificationAmount);
            notification.Token.Should().Be(viewModel.Token);
            notification.PayerId.Should().Be(viewModel.PayerId);
            notification.TransactionId.Should().Be(viewModel.TransactionId);
            notification.Value.Should().Be(viewModel.Value);
        }

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange
            var faker = new Faker();

            var notification = new Notification
            {
                Address = faker.Random.Word(),
            };

            var viewModelEdit = new NotificationUpdateViewModel
            {
                Address = faker.Random.Word(),
            };

            // Act
            _notificationEntityMapping.UpdateWith(notification, viewModelEdit);

            // Assert
            notification.Address.Should().Be(viewModelEdit.Address);
        }

        private NotificationRegisterViewModel RegisterNotification()
            => new Faker<NotificationRegisterViewModel>()
            .RuleFor(x => x.GuardId, x => x.Random.Number())
            .RuleFor(x => x.VehicleId, x => x.Random.Number())
            .RuleFor(x => x.VehiclePlate, x => x.Random.Word())
            .RuleFor(x => x.Registered, x => true)
            .RuleFor(x => x.Comments, x => x.Random.Word())
            .RuleFor(x => x.Address, x => x.Random.Word())
            .RuleFor(x => x.NotificationAmount, x => x.Random.Number())
            .RuleFor(x => x.Token, x => x.Random.Word())
            .RuleFor(x => x.PayerId, x => x.Random.Word())
            .RuleFor(x => x.TransactionId, x => x.Random.Word())
            .RuleFor(x => x.Value, x => x.Random.Number())
            .Generate();
    }
}
