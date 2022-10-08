using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [IsUserLogged]
    [Area("Driver")]
    [Route("driver/")]
    public class HomeController : Controller
    {
        private readonly ISessionAuthentication _session;

        public HomeController(ISessionAuthentication session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            TempData["name"] = _session.FindUserSession().Name;

            return View();
        }
    }
}
