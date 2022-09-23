using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [IsUserLogged]
    [IsAdministrator]
    [Area("Administrator")]
    [Route("/Administrator/Payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentsService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentsService = paymentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return View("payments");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllPayments()
        {
            var payments = _paymentsService.GetAllPayments();

            return Ok(payments);
        }
    }
}
