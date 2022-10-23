using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [IsUserLogged]
    [IsDriver]
    [Area("Driver")]
    [Route("driver/payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IVehicleService _vehicleService;
        private readonly ISessionAuthentication _session;

        public PaymentsController(IPaymentService paymentService
            , IVehicleService vehicleService
            , ISessionAuthentication sessionAuthentication)
        {
            _session = sessionAuthentication;
            _paymentService = paymentService;
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var user = _session.FindUserSession();

            if (user == null)
                return RedirectToAction("Index", "Home");

            var payments = _vehicleService.GetByUserId(user.Id);

            return Ok(payments);
        }
    }
}