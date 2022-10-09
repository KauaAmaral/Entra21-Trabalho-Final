using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.Services.Payments;

namespace Tests.Unit.Service.Services
{
    public class PaymentServiceTests
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentsRepository _paymentRepository;
        private readonly IPaymentEntityMapping _paymentEntityMapping;
    }
}
