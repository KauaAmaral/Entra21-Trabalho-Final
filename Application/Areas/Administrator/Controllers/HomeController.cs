using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [IsUserLogged]
    [Area("Administrator")]
    [Route("administrator/")]
    public class HomeController : Controller
    {
        private readonly ISessionAuthentication _session;
        private readonly IVehicleService _vehicleService;
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;

        public HomeController(ISessionAuthentication session,
                           IVehicleService vehicleService,
                           IUserService userService,
                           IPaymentService paymentService)
        {
            _session = session;
            _vehicleService = vehicleService;
            _userService = userService;
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            TempData["name"] = _session.FindUserSession().Name;
            TempData["vehicles"] = _vehicleService.GetAll().Count;
            TempData["users"] = _userService.GetAll().Count;
            TempData["notification"] = _paymentService.GetAll().Count;

            return View();
        }
    }
}
