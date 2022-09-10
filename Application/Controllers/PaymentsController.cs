using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("pagamentos")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IVehicleService _vehicleService;

        public PaymentsController(IPaymentService paymentService, IVehicleService vehicleService)
        {
            _paymentService = paymentService;
            _vehicleService = vehicleService;
        }

        public IActionResult Payments()
        {
            var vehicle = _vehicleService.GetAll();

            return View("Payments", vehicle);
        }
    }
}
