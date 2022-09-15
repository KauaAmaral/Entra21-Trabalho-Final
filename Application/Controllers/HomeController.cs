using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Email;
using Entra21.CSharp.Area21.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [IsUserLogged]
    [Route("/home")]
    public class HomeController : Controller
    {
        private readonly ISessionAuthentication _session;

        public HomeController(ISessionAuthentication session)
        {
            _session = session;
        }
        public IActionResult Index()
        {
            var name = _session.FindUserSession().Name;

            TempData["message"] = name;

            return View();
        }
    }
}
