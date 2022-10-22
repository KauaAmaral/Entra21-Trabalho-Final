using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Tests.Unit.Service.Services
{
    public class PaymentServiceTests
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentsRepository _paymentRepository;
        private readonly IPaymentEntityMapping _paymentEntityMapping;

        public PaymentServiceTests()
        {
            _paymentRepository = Substitute.For<IPaymentsRepository>();
            _paymentEntityMapping = Substitute.For<IPaymentEntityMapping>();
            _paymentService = new PaymentService(_paymentRepository, _paymentEntityMapping);
        }

        [Fact]
        public void Test_Register()
        {
            // Arrange           
            var viewModel = new PaymentRegisterViewModel
            {
                PayerId = "11",
                Token = "Adv55a2a",
                TransactionId = "123",
                UserId = 7,
                VehicleId = 11,
                Value = 1.50m
            };

            var payment = new Payment()
            {
                PayerId = viewModel.PayerId,
                Token = viewModel.Token,
                TransactionId = viewModel.TransactionId,
                UserId = viewModel.UserId,
                VehicleId = viewModel.VehicleId,
                Value = viewModel.Value
            };

            _paymentEntityMapping.RegisterWith(Arg.Is<PaymentRegisterViewModel>(
                x => x.PayerId == viewModel.PayerId &&
                    x.Token == viewModel.Token &&
                    x.TransactionId == viewModel.TransactionId &&
                    x.UserId == viewModel.UserId &&
                    x.VehicleId == viewModel.VehicleId &&
                    x.Value == viewModel.Value))
                .Returns(payment);

            // Act
            _paymentService.Register(viewModel);

            // Assert
            _paymentRepository.Received(1).Add(Arg.Is<Payment>(
                payment => ValidatePayment(payment, viewModel)));
        }

        [Fact]
        public void Test_GetById_With_Payment_Found()
        {
            // Arrange
            var id = 3;

            var expectedPayment = new Payment
            {
                PayerId = "11",
                Token = "Adv55a2a",
                TransactionId = "123",
                UserId = 7,
                VehicleId = 11,
                Value = 1.50m
            };

            _paymentRepository.GetById(Arg.Is(id))
                .Returns(expectedPayment);

            // Act
            var payment = _paymentService.GetById(id);

            // Assert
            payment.Id.Should().Be(expectedPayment.Id);
            payment.PayerId.Should().Be(expectedPayment.PayerId);
            payment.Token.Should().Be(expectedPayment.Token);
            payment.TransactionId.Should().Be(expectedPayment.TransactionId);
            payment.UserId.Should().Be(expectedPayment.UserId);
            payment.VehicleId.Should().Be(expectedPayment.VehicleId);
            payment.Value.Should().Be(expectedPayment.Value);
        }

        [Fact]
        public void Test_GetById_With_Payment_Not_Found()
        {
            // Arrange
            var id = 10;

            _paymentRepository.GetById(Arg.Is(10)).ReturnsNull();

            // Act
            var payment = _paymentService.GetById(id);

            // Assert
            payment.Should().BeNull();

            _paymentRepository.Received(1).GetById(Arg.Is(10));
        }

        [Fact]
        public void Test_UpdateLocation()
        {
            // Arrange
            var viewModel = new PaymentUpdateViewModel
            {
                Latitude = "-26.9187784",
                Longitude = "-49.0678917"
            };

            var paymentToEdit = new Payment
            {
                Latitude = "-26.9202362",
                Longitude = "-49.0648242"
            };

            _paymentEntityMapping.UpdateWith(
                Arg.Is<Payment>(x => x.Latitude == paymentToEdit.Latitude &&
                    x.Longitude == paymentToEdit.Longitude),
                Arg.Is<PaymentUpdateViewModel>(x => x.Latitude == viewModel.Latitude &&
                    x.Longitude == viewModel.Longitude))
                .Returns(paymentToEdit);

            _paymentRepository.GetByTransactionId(Arg.Is(viewModel.PayerId)).Returns(paymentToEdit);

            // Act
            _paymentService.UpdateLocation(viewModel);

            // Assert
            _paymentRepository.Received(1).Update(Arg.Is<Payment>(payment =>
                ValidatePaymentWithPaymentUpdateViewModel(payment, paymentToEdit)));
        }

        private bool ValidatePayment(Payment payment, PaymentRegisterViewModel viewModel)
        {
            payment.PayerId.Should().Be(viewModel.PayerId);
            payment.Token.Should().Be(viewModel.Token);
            payment.TransactionId.Should().Be(viewModel.TransactionId);
            payment.UserId.Should().Be(viewModel.UserId);
            payment.VehicleId.Should().Be(viewModel.VehicleId);
            payment.Value.Should().Be(viewModel.Value);

            return true;
        }

        private bool ValidatePaymentWithPaymentUpdateViewModel(Payment payment, Payment paymentExpected)
        {
            payment.VehicleId.Should().Be(paymentExpected.VehicleId);
            payment.UserId.Should().Be(paymentExpected.UserId);
            payment.PayerId.Should().Be(paymentExpected.PayerId);
            payment.TransactionId.Should().Be(paymentExpected.TransactionId);
            payment.Latitude.Should().Be(paymentExpected.Latitude);
            payment.Longitude.Should().Be(paymentExpected.Longitude);

            return true;
        }
    }
}