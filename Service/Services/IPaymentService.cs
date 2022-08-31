using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.Services
{
    public interface IPaymentService
    {
        Payment Register(PaymentRegisterViewModel registerViewModel, string pathFiles);
    }
}