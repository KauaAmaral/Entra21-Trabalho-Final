using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/guard")]
    public class GuardController : Controller
    {
        private readonly IGuardService _guardService;
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;

        public GuardController(IGuardService guardService,
                               ISessionAuthentication session)
        {
            _guardService = guardService;
            _session = session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_session.FindUserSession() != null)
                return RedirectToAction("Index", "Home");

            return View("Login");
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
            var user = new User();

            user = _userService.GetByCpf(viewModel.Cpf);

            viewModel.UserId = user.Id;

            if (!ModelState.IsValid)
                return View(viewModel);

            var guard = _guardService.Register(viewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            _session.RemoveUserSession();

            return RedirectToAction(nameof(Register));
        }

        [HttpGet("disable")]
        public IActionResult Disable()
        {
            var guard = _session.FindUserSession();

            _guardService.Disable(guard);
            _session.RemoveUserSession();

            return RedirectToAction("Index", "Login");
        }
    }
}
