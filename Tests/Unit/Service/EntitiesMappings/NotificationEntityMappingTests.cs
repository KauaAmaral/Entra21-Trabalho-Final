using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var viewModel = new NotificationRegisterViewModel
            {
                GuardId = 7,
                VehicleId = 14,
                VehiclePlate = "NFF7J99",
                Registered = true,
                Comments = "lalalal",
                Address = "Rua 1234",
                NotificationAmount = 1,
                Token = "1XC47",
                PayerId = "8",
                TransactionId = "3",
                Value = 16_50m
            };

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
            var notification = new Notification
            {
                Address = "Rua 1234"
            };

            var viewModelEdit = new NotificationUpdateViewModel
            {
                Address = "Rua 5678"
            };

            // Act
            _notificationEntityMapping.UpdateWith(notification, viewModelEdit);

            // Assert
            notification.Address.Should().Be(viewModelEdit.Address);
        }
    }    
}
