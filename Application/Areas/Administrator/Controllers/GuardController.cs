using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [IsUserLogged]
    [IsAdministrator]
    [Area("Administrator")]
    [Route("/Administrator/Guard/")]
    public class GuardController : Controller
    {
        private readonly IGuardService _guardService;
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;

        public GuardController(IGuardService guardService,
                               IUserService userService,
                               ISessionAuthentication session)
        {
            _guardService = guardService;
            _userService = userService;
            _session = session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var guards = _guardService.GetAll();

            return View("Guard/Index", guards);
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var viewModel = new GuardRegisterViewModel();

            return View(viewModel);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] GuardRegisterViewModel viewModel)
        {
            var user = _userService.GetByCpf(viewModel.Cpf);

            if (user == null)
            {
                TempData["Message"] = "Nenhum usuário com o CPF digitado";
                return View(nameof(Register));
            }
            
            viewModel.UserId = user.Id;

            if (!ModelState.IsValid)
                return View(viewModel);

            _guardService.Register(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("Update")]
        public IActionResult Update([FromQuery] int id)
        {
            var guard = _guardService.GetById(id);

            //var guardUpdateViewModel = new GuardUpdateViewModel()
            //{
            //    Id = guard.Id,
            //    IdentificationNumber = guard.IdentificationNumber
            //};

            return Ok(guard);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] GuardUpdateViewModel viewModel)
        {
            _guardService.Update(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("Delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _guardService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var guards = _guardService.GetAll();

            return Ok(guards);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var guards = _guardService.GetById(id);

            return Ok(guards);
        }
    }
}
