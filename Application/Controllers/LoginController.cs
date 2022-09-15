using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Email;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("/")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;
        private readonly IEmailService _email;

        public LoginController(IUserService userService,
                               ISessionAuthentication session,
                               IEmailService email)
        {
            _userService = userService;
            _session = session;
            _email = email;
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

        [HttpGet("register")]
        public IActionResult Register()
        {
            var viewModel = new UserRegisterViewModel();

            return View(viewModel);
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return View(userRegisterViewModel);

            if (_userService.VerifyEmails(userRegisterViewModel.Email) == false)
            {
                TempData["Message"] = "Já existe uma conta com esse email, tente novamente";

                return RedirectToAction(nameof(Login));
            }

            var token = Guid.NewGuid();

            userRegisterViewModel.Token = token;

            var user = _userService.Insert(userRegisterViewModel);

            var confirmationLink = Url.Action("ConfirmEmail", "Login",
                new { id = user.Id, token = token }, Request.Scheme);

            var email = _email.SendEMail(user.Email, "Confirmação de email",
                @$"<p>Olá, {user.Name}, como você está?
                <br>
                Confirme seu cadastro <a href='{confirmationLink}'>aqui</a>
                <br>
                Caso você não seja redirecionado, acesse pelo link abaixo:
                <br>
                {confirmationLink}<p>");

            return View(nameof(ConfirmEmail));
        }

        [HttpGet("ConfirmEmail")]
        public IActionResult ConfirmEmail([FromQuery] int id, Guid token)
        {
            var user = _userService.GetById(id);

            if (user == null || user.Token != token)
                TempData["message"] = "Não existe nenhum usuário referido!";

            else if (user.IsEmailConfirmed == true)
                TempData["message"] = "O usuário já possui o link confirmado!";

            else if (user.TokenExpiredDate.TimeOfDay < DateTime.Now.TimeOfDay)
                TempData["message"] = "O link foi espirado! Tente criar outra conta";

            else
            {
                TempData["message"] = "O usuário foi confirmado!";
                _userService.UpdateVerifyEmail(user.Id);
            }
                
            return View(nameof(ConfirmEmail));
        }
    }
}
