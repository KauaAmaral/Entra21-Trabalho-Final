using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Logged.Controllers
{
    [IsUserLogged]
    [Area("Logged")]
    [Route("Logged")]
    public class HomeController : Controller
    {
        private readonly ISessionAuthentication _session;

        public HomeController(ISessionAuthentication session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            var user = _session.FindUserSession();

            TempData["name"] = user.Name;

            if (user.Hierarchy == Repository.Enums.UserHierarchy.Administrador)
                return View("HomeAdministrator");

            else if (user.Hierarchy == Repository.Enums.UserHierarchy.Guarda) 
                return View("HomeGuard");

            return View("HomeDriver");
        }
    }
}
