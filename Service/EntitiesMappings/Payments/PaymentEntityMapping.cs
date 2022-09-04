using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Payments
{
    internal class PaymentEntityMapping : IPaymentEntityMapping
    {
        public Payment RegisterWith(PaymentRegisterViewModel registerViewModel, string path) =>
            new Payment
            {
                UserId = registerViewModel.UserId.GetValueOrDefault(),
                VehicleId = registerViewModel.VehicleId.GetValueOrDefault()
            };
    }
}
