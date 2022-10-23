using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Guard.Controllers
{
    [IsUserLogged]
    [IsGuard]
    [Area("Guard")]
    [Route("guard/")]
    public class HomeController : Controller
    {
        private readonly ISessionAuthentication _session;
        private readonly INotificationService _notificationService;

        public HomeController(ISessionAuthentication session,
                              INotificationService notificationService)
        {
            _session = session;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            TempData["name"] = _session.FindUserSession().Name;
            TempData["notifications"] = _notificationService.GetAll().Count;

            return View();
        }
    }
}
