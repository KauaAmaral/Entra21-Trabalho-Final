using Entra21.CSharp.Area21.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Guard.Controllers
{
    [IsUserLogged]
    [IsGuard]
    [Area("Guard")]
    [Route("/Guard/Notifications/")]
    public class NotificationsGuardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
