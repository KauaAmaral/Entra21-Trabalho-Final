using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Public.Controllers
{
    [Area("Public")]
    [Route("alerta")]
    public class AlertController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;

        public AlertController(IUserService userService,
                               ISessionAuthentication session)
        {
            _userService = userService;
            _session = session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Administrator")]
        public IActionResult Administrator()
        {
            TempData["Message"] = "Você deve ser um administrador para acessar essa página";
            return View(nameof(Index));
        }  
        
        [HttpGet("Guard")]
        public IActionResult Guard()
        {
            TempData["Message"] = "Você deve ser um guarda para acessar essa página";
            return View(nameof(Index));
        }
        
        [HttpGet("Driver")]
        public IActionResult Driver()
        {
            TempData["Message"] = "Você deve ser um motorista para acessar essa página";
            return View(nameof(Index));
        }
    }
}
