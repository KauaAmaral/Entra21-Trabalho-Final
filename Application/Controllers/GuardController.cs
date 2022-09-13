using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("guard")]
    public class GuardController : Controller
    {
        private readonly IGuardService _guardService;
        private readonly ISessionAuthentication _session;

        public GuardController(IGuardService guardService)
        {
            _guardService = guardService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var guards = _guardService.GetAll();

            return Ok(guards);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var guards = _guardService.GetById(id);

            if (guards == null)
                return NotFound();

            return Ok(guards);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            var viewModel = new GuardRegisterViewModel();

            return View(viewModel);
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] GuardRegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var guard = _guardService.Register(viewModel);

            return RedirectToAction(nameof(Update), new { id = guard.Id });
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            _session.RemoveUserSession();

            return RedirectToAction(nameof(Register));
        }

        // TODO: Adicionar nos users botão para desativar conta guarda
        [HttpGet("closeGuardAccount")]
        public IActionResult Update([FromQuery] int id)
        {
            var viewModel = _guardService.GetById(id);

            return View(viewModel);
        }

        [HttpPost("closeGuardAccount")]
        public IActionResult Update([FromQuery] GuardUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var updated = _guardService.Update(viewModel);

            return RedirectToAction(nameof(Update), new { id = viewModel.Id });
        }
    }
}
