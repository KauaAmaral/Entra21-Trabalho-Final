using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Payments
{
    public interface IPaymentEntityMapping
    {
        Payment RegisterWith(PaymentRegisterViewModel registerViewModel, string path);
    }
}