using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
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
            return View();
        }

        [HttpGet("update")]
        public IActionResult Update([FromQuery] int id)
        {
            var notification = _notificationService.GetById(id);

            var notificationUpdateViewMode = new NotificationUpdateViewModel
            {
                Id = notification.Id,
            };

            return View();
        }

        [HttpPost("update")]
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
    }
}
