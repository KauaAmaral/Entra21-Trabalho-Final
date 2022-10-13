using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/pagamentos")]
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

        public IActionResult Payments()
        {
            var user = _session.FindUserSession();
            
            var vehicle = _vehicleService.GetByUserId(user.Id);

            return View("Payments", vehicle);
        }
    }
}
