using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("Driver/Notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly ISessionAuthentication _session;

        public NotificationController(
            INotificationService notificationService,
            ISessionAuthentication sessionAuthentication
            )
        {
            _notificationService = notificationService;
            _session = sessionAuthentication;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _session.FindUserSession();
            var notifications = _notificationService.GetByVehicleId(user.Id);

            return View("Index", notifications);
        }

        //[HttpGet("GetByVehicleId")]
        //public IActionResult GetByVehicleId()
        //{
        //    var user = _session.FindUserSession();
        //    var notificatios = _notificationService.GetByVehicleId(user.Id);

        //    return Ok(notificatios);
        //}



        //[HttpGet("")]
        //public IActionResult Index()
        //{
        //    var notifications = _notificationService.GetAll();

        //    return View("Notifications/Index", notifications);
        //}

        //[HttpPost("update")]
        //public IActionResult Update([FromBody] NotificationUpdateViewModel notificationUpdateViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);

        //    var update = _notificationService.Update(notificationUpdateViewModel);

        //    return Ok(new { status = update });
        //}

        //[HttpGet("getAll")]
        //public IActionResult GetAll()
        //{
        //    var notifications = _notificationService.GetAll();

        //    return Ok(notifications);
        //}

        //[HttpGet("getById")]
        //public IActionResult GetById([FromQuery] int id)
        //{
        //    var notifications = _notificationService.GetById(id);

        //    return Ok(notifications);
        //}

        //[HttpGet("register")]
        //public IActionResult Register([FromQuery] NotificationRegisterViewModel notificationRegisterViewModel)
        //{
        //    var plate = notificationRegisterViewModel.VehiclePlate;
        //    var vehicle = _vehicleService.GetByVehiclePlate(plate);
        //    var validPayment = false;
        //    if (vehicle != null)
        //        validPayment = _paymentService.ValidPayment(vehicle);

        //    if (!validPayment)
        //    {
        //        if (vehicle == null)
        //        {
        //            notificationRegisterViewModel.Registered = false;
        //            ViewBag.VehicleType = GetVehicleType();
        //        }
        //        else
        //        {
        //            notificationRegisterViewModel.VehiclePlate = vehicle.LicensePlate;
        //            notificationRegisterViewModel.Type = vehicle.Type;
        //            notificationRegisterViewModel.Registered = true;
        //            var vehicleType = GetVehicleType();
        //            ViewBag.VehicleType = vehicleType;
        //        }

        //        return View("Notifications/Register", notificationRegisterViewModel);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Checkout");
        //    }
        //}

        //[HttpPost("registerNotification")]
        //public IActionResult RegisterNotification([FromForm] NotificationRegisterViewModel notificationRegisterViewModel)
        //{
        //    var user = _session.FindUserSession();

        //    if (user != null)
        //        notificationRegisterViewModel.GuardId = _guardService.GetByUserId(user.Id).Id;
        //    else
        //        return RedirectToAction("Index", "Home");

        //    var vehicle = _vehicleService.GetByVehiclePlate(notificationRegisterViewModel.VehiclePlate);

        //    if (vehicle != null)
        //    {
        //        notificationRegisterViewModel.VehicleId = vehicle.Id;
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.VehicleType = GetVehicleType();
        //        return View(notificationRegisterViewModel);
        //    }

        //    _notificationService.SetNotification(notificationRegisterViewModel);

        //    return RedirectToAction("Home");
        //}

        //[HttpGet("checkout")]
        //public IActionResult Checkout()
        //{
        //    return View("Notifications/Checkout");
        //}

        private List<string> GetVehicleType()
        {
            return Enum
                .GetNames<VehicleType>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}