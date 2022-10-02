using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;
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
            var viewModel = new PaymentRegisterViewModel
            {
                Token = "123abc@#",
                PayerId = "14",
                TransactionId = "17",
                UserId = 4,
                VehicleId = 16,
                Value = 16.50m
            };
        }
    }
}
