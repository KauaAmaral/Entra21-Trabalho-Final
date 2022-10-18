using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.Services.Payments
{
    public interface IPaymentService
    {
        Payment Register(PaymentRegisterViewModel registerViewModel);
        Payment UpdateLocation(PaymentUpdateViewModel ViewModel);
        IList<PaymentIndexViewModel> GetAll();
        Payment GetById(int id);
        bool ValidPayment(Vehicle vehicle);
 
    }
}   