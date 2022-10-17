using Bogus;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Service.EntitiesMappings
{
    public class PaymentEntityMappingTests
    {
        private readonly IPaymentEntityMapping _paymentEntityMapping;
        public PaymentEntityMappingTests()
        {
            _paymentEntityMapping = new PaymentEntityMapping();
        }

        [Fact]
        public void Test_RegisterWith()
        {
            // Arrange            
            var viewModel = RegisterPayment();

            // Act
            var payment = _paymentEntityMapping.RegisterWith(viewModel);

            // Assert
            payment.Token.Should().Be(viewModel.Token);
            payment.PayerId.Should().Be(viewModel.PayerId);
            payment.TransactionId.Should().Be(viewModel.TransactionId);
            payment.UserId.Should().Be(viewModel.UserId);
            payment.VehicleId.Should().Be(viewModel.VehicleId);
            payment.Value.Should().Be(viewModel.Value);
        }

        private PaymentRegisterViewModel RegisterPayment()
            => new Faker<PaymentRegisterViewModel>()
            .RuleFor(x => x.Token, p => p.Random.Word())
            .RuleFor(x => x.PayerId, p => p.Random.Word())
            .RuleFor(x => x.TransactionId, p => p.Random.Word())
            .RuleFor(x => x.UserId, p => p.Random.Number())
            .RuleFor(x => x.VehicleId, p => p.Random.Number())
            .RuleFor(x => x.Value, p => p.Random.Number())
            .Generate();
    }
}