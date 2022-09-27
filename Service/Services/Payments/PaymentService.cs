﻿using Entra21.CSharp.Area21.Repository.Entities;
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

        public Payment Register(PaymentRegisterViewModel registerViewModel)
        {
            var payment = _paymentEntityMapping.RegisterWith(registerViewModel);

            _paymentRepository.Add(payment);

            return payment;
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