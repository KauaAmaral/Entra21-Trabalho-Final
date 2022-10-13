using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Notifications;
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

        [HttpGet("GetByVehicleId")]
        public IActionResult GetByVehicleId()
        {
            var user = _session.FindUserSession();
            var notificatios = _notificationService.GetByVehicleId(user.Id);

            return Ok(notificatios);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId()
        {
            var user = _session.FindUserSession();
            var notifications = _notificationService.GetByVehicleId(user.Id);

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