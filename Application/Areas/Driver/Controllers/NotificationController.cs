using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
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
        private readonly IGuardService _guardService;

        public NotificationController(
            INotificationService notificationService,
            IGuardService guardService )
        {
            _notificationService = notificationService;
            _guardService = guardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] NotificationRegisterViewModel notificationRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var notification = _notificationService.Register(notificationRegisterViewModel);

            return Ok (notification);
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