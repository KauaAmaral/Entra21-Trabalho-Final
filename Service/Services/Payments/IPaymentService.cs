using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.Services.Payments
{
    public interface IPaymentService
    {
        Payment Register(PaymentRegisterViewModel registerViewModel);
    }
}