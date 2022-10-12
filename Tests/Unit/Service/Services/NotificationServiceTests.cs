using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Repository.Repositories.Notifications;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Tests.Unit.Service.Services
{
    public class NotificationServiceTests
    {
        private readonly INotificationService _notificationService;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationEntityMapping _notificationEntityMapping;

        public NotificationServiceTests()
        {
            _notificationRepository = Substitute.For<INotificationRepository>();
            _notificationEntityMapping = Substitute.For<INotificationEntityMapping>();
            _notificationService = new NotificationService(_notificationRepository, _notificationEntityMapping);
        }

        [Fact]
        public void Test_Register()
        {
            // Arrange           
            var viewModel = new NotificationRegisterViewModel
            {
                Address = "Rua XV de Novembro",
                Comments = "Horário Expirado",
                GuardId = 7,
                NotificationAmount = 2,
                PayerId = "8",
                Registered = true,
                Token = "15",
                TransactionId = "92",
                Type = VehicleType.Carro,
                Value = 1.50m,
                VehicleId = 14,
                VehiclePlate = "ONS0209"
            };

            // Act
            _notificationService.Register(viewModel);

            // Assert
            _notificationRepository.Received(1).Add(Arg.Is<Notification>(
                notification => ValidateNotification(notification, viewModel)));
        }

        [Fact]
        public void Test_Update_With_Notification_Found()
        {
            // Arrange
            var viewModel = new NotificationUpdateViewModel
            {
                Id = 3,
                Address = "Rua XV de Novembro",
                Comments = "Horário Expirado",
                GuardId = 7,
                NotificationAmount = 2,
                PayerId = "8",
                Token = "15",
                TransactionId = "92",
                Type = VehicleType.Carro,
                Value = 1.50m,
                VehicleId = 14,
            };

            var notificationToEdit = new Notification
            {
                Id = 8,
                Address = "Rua 7 de Setembro",
                Comments = "Horário Expirado",
                GuardId = 7,
                NotificationAmount = 2,
                PayerId = "8",
                Token = "15",
                TransactionId = "92",
                Type = VehicleType.Moto,
                Value = 1.50m,
                VehicleId = 26,
            };

            _notificationRepository.GetById(Arg.Is(viewModel.Id)).Returns(notificationToEdit);

            // Act
            _notificationService.Update(viewModel);

            // Assert
            _notificationRepository.Received(1).Update(Arg.Is<Notification>(notification =>
                ValidateNotificationWithNotificationUpdateViewModel(notification, viewModel)));
        }

        [Fact]
        public void Test_Update_With_Notification_Not_Found()
        {
            // Arrange
            var viewModel = new NotificationUpdateViewModel
            {
                Id = 3,
                Address = "Rua XV de Novembro",
                Comments = "Horário Expirado",
                GuardId = 7,
                NotificationAmount = 2,
                PayerId = "8",
                Token = "15",
                TransactionId = "92",
                Type = VehicleType.Carro,
                Value = 1.50m,
                VehicleId = 14,
            };

            _notificationRepository.GetById(Arg.Is(viewModel.Id)).ReturnsNull();

            // Act
            _notificationService.Update(viewModel);

            // Assert
            _notificationRepository
                .DidNotReceive()
                .Update(Arg.Any<Notification>());
        }

        [Fact]
        public void Test_GetById_With_Notification_Found()
        {
            // Arrange
            var id = 3;

            var expectedNotification = new Notification
            {
                Address = "Rua XV de Novembro",
                Comments = "Horário Expirado",
                GuardId = 7,
                NotificationAmount = 2,
                PayerId = "8",                
                Token = "15",
                TransactionId = "92",
                Type = VehicleType.Carro,
                Value = 1.50m,
                VehicleId = 14,               
            };

            _notificationRepository.GetById(Arg.Is(id))
                .Returns(expectedNotification);

            // Act
            var notification = _notificationService.GetById(id);

            // Assert
            notification.Id.Should().Be(expectedNotification.Id);
            notification.GuardId.Should().Be(expectedNotification.GuardId);
            notification.VehicleId.Should().Be(expectedNotification.VehicleId);
            notification.Comments.Should().Be(expectedNotification.Comments);
            notification.Address.Should().Be(expectedNotification.Address);
            notification.NotificationAmount.Should().Be(expectedNotification.NotificationAmount);
            notification.Token.Should().Be(expectedNotification.Token);
            notification.PayerId.Should().Be(expectedNotification.PayerId);
            notification.TransactionId.Should().Be(expectedNotification.TransactionId);
            notification.Value.Should().Be(expectedNotification.Value);
            notification.Type.Should().Be(expectedNotification.Type);
        }

        [Fact]
        public void Test_GetById_With_Notification_Not_Found()
        {
            // Arrange
            var id = 10;

            _notificationRepository.GetById(Arg.Is(10)).ReturnsNull();

            // Act
            var notification = _notificationService.GetById(id);

            // Assert
            notification.Should().BeNull();

            _notificationRepository.Received(1).GetById(Arg.Is(10));
        }

        private bool ValidateNotification(Notification notification, NotificationRegisterViewModel viewModel)
        {
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
            notification.Type.Should().Be(viewModel.Type);

            return true;
        }

        private bool ValidateNotificationWithNotificationUpdateViewModel(Notification notification, NotificationUpdateViewModel viewModel)
        {
            notification.Id.Should().Be(viewModel.Id);
            notification.GuardId.Should().Be(viewModel.GuardId);
            notification.VehicleId.Should().Be(viewModel.VehicleId);
            notification.Comments.Should().Be(viewModel.Comments);
            notification.Address.Should().Be(viewModel.Address);
            notification.NotificationAmount.Should().Be(viewModel.NotificationAmount);
            notification.Token.Should().Be(viewModel.Token);
            notification.PayerId.Should().Be(viewModel.PayerId);
            notification.TransactionId.Should().Be(viewModel.TransactionId);
            notification.Value.Should().Be(viewModel.Value);
            notification.Type.Should().Be(viewModel.Type);

            return true;
        }
    }
}
