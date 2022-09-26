using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Payments;

namespace Entra21.CSharp.Area21.Service.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentsRepository _paymentRepository;
        private readonly IPaymentEntityMapping _paymentEntityMapping;
        private readonly IVehicleRepository _vehicleRepository;

        public PaymentService(
           IPaymentsRepository paymentRepository,
           IPaymentEntityMapping paymentEntityMapping,
           IVehicleRepository vehicleRepository)
        {
            _paymentRepository = paymentRepository;
            _paymentEntityMapping = paymentEntityMapping;
            _vehicleRepository = vehicleRepository;
        }

        public Payment Details(Vehicle vehicles)
        {
            var vehicle = _vehicleRepository.GetById(vehicles.Id);

            return Details(vehicle);
        }

        public IList<Payment> GetAllPayments() =>
            _paymentRepository.GetAll();

        public Payment Register(PaymentRegisterViewModel registerViewModel)
        {
            var payment = _paymentEntityMapping.RegisterWith(registerViewModel);

            _paymentRepository.Add(payment);

            return payment;
        }
    }
}