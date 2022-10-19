using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsRepository _paymentRepository;
        private readonly IPaymentEntityMapping _paymentEntityMapping;

        public PaymentService(
           IPaymentsRepository paymentRepository,
           IPaymentEntityMapping paymentEntityMapping)
        {
            _paymentRepository = paymentRepository;
            _paymentEntityMapping = paymentEntityMapping;
        }

        public IList<PaymentIndexViewModel> GetAll()
        {
            var payments = _paymentRepository.GetAll();

            return payments.Select(x => new PaymentIndexViewModel
            {
                Id = x.Id,
                Model = x.Vehicle.Model,
                LicensePlate = x.Vehicle.LicensePlate,
                Type = x.Vehicle.Type
            }).ToList();
        }

        public Payment GetById(int id)
        {
            var payment = _paymentRepository.GetById(id);

            return payment;
        }

        public IList<PaymentsLocationsViewModel> GetLocations()
        {
            var paymentsLocations = _paymentRepository.GetLocations();

            return paymentsLocations.Select(x => new PaymentsLocationsViewModel
            {
                Latitude = x.Latitude,
                Longitude = x.Longitude
            }).ToList();
        }

        public Payment Register(PaymentRegisterViewModel registerViewModel)
        {
            var payment = _paymentEntityMapping.RegisterWith(registerViewModel);

            _paymentRepository.Add(payment);

            return payment;
        }

        public bool UpdateLocation(PaymentUpdateViewModel viewModel)
        {
            var payment = _paymentRepository.GetByTransactionId(viewModel.TransactionId);

            if (payment == null)
                return false;

            payment = _paymentEntityMapping.UpdateWith(payment, viewModel);
            _paymentRepository.Update(payment);

            return true;
        }

        public bool ValidPayment(Vehicle vehicle)
        {
            var validPayment = true;
            var payment = _paymentRepository.ValidPayment(vehicle.Id);
            if (payment == null || payment.CreatedAt.AddHours(1) <= (DateTime.Now))
            {
                validPayment = false;
            }
            return validPayment;
        }
    }
}