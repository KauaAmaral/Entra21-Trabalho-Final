using Entra21.CSharp.Area21.Service.Services.Guards;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("guarda")]
    public class GuardController : Controller
    {
        private readonly IGuardService _guardService;

        public GuardController(IGuardService guardService)
        {
            _guardService = guardService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
