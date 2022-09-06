using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
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

        [HttpPost("cadastrar")]
        public IActionResult Register([FromForm] GuardRegisterViewModel guardRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var guard = _guardService.Register(guardRegisterViewModel);

            return Ok(guard);
        }
    }
}
