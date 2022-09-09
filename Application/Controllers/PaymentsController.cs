using Entra21.CSharp.Area21.Service.Services.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("pagamentos")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public IActionResult Payments()
        {
            return View("Payments");
        }
    }
}
