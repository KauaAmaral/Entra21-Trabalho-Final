using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [IsAdministrator]
    [Route("Administrator/Notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IVehicleService _vehicleService;
        private readonly IPaymentService _paymentService;
        private readonly IGuardService _guardService;

        public NotificationController(
        INotificationService notificationService,
        IVehicleService vehicleService,
        IGuardService guardService,
        IPaymentService paymentService
        )
        {
            _notificationService = notificationService;
            _vehicleService = vehicleService;
            _paymentService = paymentService;
            _guardService = guardService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var notifications = _notificationService.GetAll();

            return View("Index", notifications);
            //return View();
        }

        [HttpGet("update")]
        public IActionResult Update([FromQuery] int id)
        {
            var notification = _notificationService.GetById(id);

            var notificationUpdateViewMode = new NotificationUpdateViewModel
            {
                Id = notification.Id,
                Address = notification.Address,
                Comments = notification.Comments,
                GuardId = notification.GuardId,
                NotificationAmount = notification.NotificationAmount,
                PayerId = notification.PayerId,
                Value = notification.Value,
                Token = notification.Token,
                Type = notification.Type,
                TransactionId = notification.TransactionId,
                VehiclePlate = notification.VehicleLicensePlate,
                VehicleId = notification.VehicleId,
                Registered =notification.RegisteredVehicle
            };

            var vehicleType = GetVehicleType();
            ViewBag.VehicleType = vehicleType;

            return View("update", notificationUpdateViewMode);
        }

        [HttpPost("updateNotification")]
        public IActionResult Update([FromForm] NotificationUpdateViewModel notificationUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View(notificationUpdateViewModel);

            var update = _notificationService.Update(notificationUpdateViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var notifications = _notificationService.GetAll();

            return View("Index", notifications);
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _notificationService.Delete(id);

            return RedirectToAction("Index");
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
