using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Email;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Guard.Controllers
{
    [IsUserLogged]
    [IsGuard]
    [Area("Guard")]
    [Route("/Guard/Notification/")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IVehicleService _vehicleService;
        private readonly IPaymentService _paymentService;
        private readonly ISessionAuthentication _session;
        private readonly IGuardService _guardService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _userName = "AeHh1KwTDiCTJlkmPVoWT5qj9YMp0dwnhAStwYVE7VZiaPN2jfJjMm7UJ6B9TMXFkVqFNkmpzpfinpJR";
        private readonly string _passwd = "EHqhokF9mvWolaWgw04hay43lNAuCcLNHZ8XBpmm0cLSYUxdAYnbBI6dhiaCXtI54qJJ-EF3VS0IMGfx";
        private readonly string _url = "https://api-m.sandbox.paypal.com";

        public NotificationController(
            INotificationService notificationService,
            IVehicleService vehicleService,
            IGuardService guardService,
            IPaymentService paymentService,
            ISessionAuthentication sessionAuthentication,
            IEmailService emailService,
            IUserService userService,
            IWebHostEnvironment webHostEnvironment 
            )
        {
            _notificationService = notificationService;
            _vehicleService = vehicleService;
            _paymentService = paymentService;
            _session = sessionAuthentication;
            _guardService = guardService;
            _emailService = emailService;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll();

            return View("Index", notifications);
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

                return View("Register", notificationRegisterViewModel);
            }
            else
            {
                return RedirectToAction("Checkout");
            }
        }

        [HttpPost("registerNotification")]
        public IActionResult RegisterNotification([FromForm] NotificationRegisterViewModel notificationRegisterViewModel)
        {
            var user = _session.FindUserSession();

            if (user != null)
                notificationRegisterViewModel.GuardId = _guardService.GetByUserId(user.Id).Id;
            else
                return RedirectToAction("Index", "Home");

            var vehicle = _vehicleService.GetByVehiclePlate(notificationRegisterViewModel.VehiclePlate);

            if (vehicle != null)
                notificationRegisterViewModel.VehicleId = vehicle.Id;

            var notification = _notificationService.SetNotification(notificationRegisterViewModel);

            var link = Url.ActionLink("Check", "Notification", new { Area = "Public" });

            link += $"?id={notification.Id}";

            var fileName = _notificationService.CreatePdfNotifications(notification, link, _webHostEnvironment.WebRootPath);

            if (vehicle != null)
            {
                notificationRegisterViewModel.VehicleId = vehicle.Id;

                var currentVehicle = _vehicleService.GetById(vehicle.Id);

                var currentUser = _userService.GetById(currentVehicle.UserId);

                _emailService.SendEMail(currentUser.Email, "Notificação gerada", $@"
Caro {currentUser.Name}, uma nova notificação foi gerada, confira em anexo.
<br>
<br>
<br>
Atenciosamente,
Efraim Calebe Mertens
", fileName);
            }

            if (!ModelState.IsValid)
            {
                ViewBag.VehicleType = GetVehicleType();
                return View(notificationRegisterViewModel);
            }

            TempData["ShowMessageToastr"] = "Notificação cadastrada com sucesso";

            return RedirectToAction("Checkout");
        }

        [HttpGet("checkout")]
        public IActionResult Checkout()
        {
            return View("Checkout");
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