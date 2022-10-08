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
            var faker = new Faker();

            var viewModel = new PaymentRegisterViewModel
            {
                Token = faker.Random.Word(),
                PayerId = "14",
                TransactionId = "17",
                UserId = faker.Random.Number(),
                VehicleId = faker.Random.Number(),
                Value = faker.Random.Number()
            };

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
    }
}
