using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
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

        public NotificationController(
            INotificationService notificationService,
            IVehicleService vehicleService)
        {
            _notificationService = notificationService;
            _vehicleService = vehicleService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll();

            return View("Notifications/Index", notifications);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View("Notifications/Register");
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] NotificationRegisterViewModel notificationRegisterViewModel)
        {
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
    }
}