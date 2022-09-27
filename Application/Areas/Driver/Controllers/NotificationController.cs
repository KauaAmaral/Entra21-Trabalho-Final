using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IVehicleService _vehicleService;
        private readonly IPaymentService _paymentService;

        public NotificationController(
            INotificationService notificationService,
            IVehicleService vehicleService,
            IPaymentService paymentService
            )
        {
            _notificationService = notificationService;
            _vehicleService = vehicleService;
            _paymentService = paymentService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll();

            return View("Notifications/Index", notifications);
        }


        [HttpPost("update")]
        public IActionResult Update([FromBody] NotificationUpdateViewModel notificationUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var update = _notificationService.Update(notificationUpdateViewModel);

            return Ok(new { status = update });
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var notifications = _notificationService.GetAll();

            return Ok(notifications);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var notifications = _notificationService.GetById(id);

            return Ok(notifications);
        }

        [HttpGet("register")]
        public IActionResult Register([FromQuery] NotificationRegisterViewModel notificationRegisterViewModel)
        {
            var plate = notificationRegisterViewModel.VehiclePlate;
            var vehicle = _vehicleService.GetByVehiclePlate(plate);
            var validPayment = false;
            if (vehicle != null)
                validPayment = _paymentService.ValidPayment(vehicle);

            if (!validPayment)
            {
                if (vehicle == null)
                {
                    notificationRegisterViewModel.Registered = false;
                    ViewBag.VehicleType = GetVehicleType();
                }
                else
                {
                    notificationRegisterViewModel.VehiclePlate = vehicle.LicensePlate;
                    notificationRegisterViewModel.Type = vehicle.Type;
                    notificationRegisterViewModel.Registered = true;
                    var vehicleType = GetVehicleType();
                    ViewBag.VehicleType = vehicleType;
                }

                return View("Notifications/Register", notificationRegisterViewModel);
            }
            else
            {
                return RedirectToAction("Checkout");
            }
        }

        [HttpPost("registerNotification")]
        public IActionResult RegisterNotification([FromForm] NotificationRegisterViewModel notificationRegisterViewModel)
        {
            var NotificationText = "";
            var vehicle = _vehicleService.GetByVehiclePlate(notificationRegisterViewModel.VehiclePlate);
            
            if (vehicle == null)
            {
                TempData["Message"] = "Placa não cadastrada";
                return View(nameof(Register));
            }

            notificationRegisterViewModel.VehicleId = vehicle.Id;

            if (!ModelState.IsValid)
                return View(notificationRegisterViewModel);

            _notificationService.Register(notificationRegisterViewModel);

            return RedirectToAction("Index");

        }

        [HttpGet("checkout")]
        public IActionResult Checkout()
        {
            return View("Notifications/Checkout");
        }

        private List<string> GetVehicleType()
        {
            return Enum
                .GetNames<VehicleType>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}