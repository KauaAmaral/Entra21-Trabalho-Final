using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Entra21.CSharp.Area21.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Entra21.CSharp.Area21.Service.Authentication;
using Microsoft.AspNetCore.Identity;
using Entra21.CSharp.Area21.Repository.Entities;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;

        public LoginController(IUserService userService,
                               ISessionAuthentication session)
        {
            _userService = userService;
            _session = session;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_session.FindUserSession() != null)
                return RedirectToAction("Index", "Home");

            return View("Login");
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
                return View(userLoginViewModel);

            var user = _userService.GetByEmailAndPassword(userLoginViewModel.Email, userLoginViewModel.Password);

            if (user != null)
            {
                _session.CreateUserSession(user);
                return RedirectToAction("Index");
            }
            else
                TempData["Message"] = "Não existe um usuário com esse e-mail e/ou senha";

            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            _session.RemoveUserSession();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var viewModel = new UserRegisterViewModel();

            return View(viewModel);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return View(userRegisterViewModel);

            var user = _userService.Insert(userRegisterViewModel);
            
            var token = Guid.NewGuid();

            var confirmationLink = Url.Action("ConfirmEmail", "Login",
                new { userId = user.Id, token = token }, Request.Scheme);

            TempData["teste"] = confirmationLink;


            return View(nameof(VerifyEmail));
        }

        public IActionResult VerifyEmail()
        {
            return View(nameof(VerifyEmail));
        }
    }
}
