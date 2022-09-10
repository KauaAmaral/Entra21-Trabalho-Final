using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("guard")]
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

        // TODO: Ajustar para retornar o usuario
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

        [HttpGet("update")]
        public IActionResult Update([FromQuery] int id)
        {
            var viewModel = _guardService.GetById(id);

            return View(viewModel);
        }

        [HttpPost("update")]
        public IActionResult Update([FromQuery] GuardUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var updated = _guardService.Update(viewModel);

            return RedirectToAction(nameof(Update), new { id = viewModel.Id });
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _guardService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
