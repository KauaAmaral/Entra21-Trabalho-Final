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

        [HttpGet("obterTodos")]
        public IActionResult GetAll()
        {
            var guards = _guardService.GetAll();

            return Ok(guards);
        }

        [HttpGet("obterPorId")]
        public IActionResult GetById([FromQuery] int id)
        {
            var guards = _guardService.GetById(id);

            return Ok(guards);
        }

        [HttpPost("cadastrar")]
        public IActionResult Register([FromForm] GuardRegisterViewModel guardRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var guard = _guardService.Register(guardRegisterViewModel);

            return Ok(guard);
        }

        [HttpPost("editar")]
        public IActionResult Update([FromQuery] GuardUpdateViewModel guardUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var updated = _guardService.Update(guardUpdateViewModel);

            return Ok(new { status = updated });
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var deleted = _guardService.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
