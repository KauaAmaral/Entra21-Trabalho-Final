using Bogus;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
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
            notification.Value.Should().Be(viewModel.Value);
            notification.Type.Should().Be(viewModel.Type);
        }

        [Fact]
        public void Test_UpdateWith()
        {
            // Arrange            
            var notification = NotificationCreated();

            var viewModelEdit = UpdateNotification();

            // Act
            _notificationEntityMapping.UpdateWith(notification, viewModelEdit);

            // Assert
            notification.Address.Should().Be(viewModelEdit.Address);
        }

        [Fact]
        public void Test_UpdateWithPayment()
        {
            // Arrange
            var notificationPayment = NotificationCreated();

            var viewModelEdit = UpdatePaymentNotification();

            // Act
            _notificationEntityMapping.UpdateWithPayment(notificationPayment, viewModelEdit);

            // Assert
            notificationPayment.PayerId.Should().Be(viewModelEdit.PayerId);
            notificationPayment.TransactionId.Should().Be(viewModelEdit.TransactionId);
            notificationPayment.Token.Should().Be(viewModelEdit.Token);
        }

        private NotificationRegisterViewModel RegisterNotification()
            => new Faker<NotificationRegisterViewModel>()
            .RuleFor(x => x.GuardId, x => x.Random.Number())
            .RuleFor(x => x.VehicleId, x => x.Random.Number())
            .RuleFor(x => x.VehiclePlate, x => x.Random.Word().ToUpper())
            .RuleFor(x => x.Registered, x => true)
            .RuleFor(x => x.Comments, x => x.Random.Word())
            .RuleFor(x => x.Address, x => "Rua XV de Novembro")            
            .RuleFor(x => x.Value, x => x.Random.Number())
            .RuleFor(x => x.Type, x => VehicleType.Carro)
            .Generate();

        private Notification NotificationCreated()
            => new Faker<Notification>()         
            .RuleFor(x => x.Comments, x => x.Random.Word())
            .RuleFor(x => x.Address, x => x.Random.Word())
            .RuleFor(x => x.VehicleLicensePlate, x => x.Random.Word().ToUpper())
            .Generate();

        private NotificationUpdateViewModel UpdateNotification()
            => new Faker<NotificationUpdateViewModel>()          
            .RuleFor(x => x.Comments, x => x.Random.Word())            
            .RuleFor(x => x.Address, x => x.Random.Word())            
            .RuleFor(x => x.VehiclePlate, x => x.Random.Word().ToUpper())
            .Generate();

        private NotificationUpdateViewModel UpdatePaymentNotification()
             => new Faker<NotificationUpdateViewModel>()
            .RuleFor(x => x.PayerId, x => x.Random.Word())
            .RuleFor(x => x.TransactionId, x => x.Random.Word())
            .RuleFor(x => x.Token, x => x.Random.Word())            
            .Generate();
    }
}