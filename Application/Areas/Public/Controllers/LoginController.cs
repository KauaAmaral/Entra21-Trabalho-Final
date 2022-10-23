using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Email;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Public.Controllers
{
    [Area("Public")]
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

        public IActionResult Index()
        {
            if (_session.FindUserSession() != null)
            {
                if (_session.FindUserSession().Hierarchy == Repository.Enums.UserHierarchy.Administrador)
                    return RedirectToAction("Index", "Home", new { Area = "administrator" });

                else if (_session.FindUserSession().Hierarchy == Repository.Enums.UserHierarchy.Guarda)
                    return RedirectToAction("Index", "Home", new { Area = "guard" });

                else
                    return RedirectToAction("Index", "Home", new { Area = "driver" });
            }

            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            if (_session.FindUserSession() != null)
            {
                if (_session.FindUserSession().Hierarchy == Repository.Enums.UserHierarchy.Administrador)
                    return RedirectToAction("Index", "Home", new { Area = "administrator" });

                else if (_session.FindUserSession().Hierarchy == Repository.Enums.UserHierarchy.Guarda)
                    return RedirectToAction("Index", "Home", new { Area = "guard" });

                else
                    return RedirectToAction("Index", "Home", new { Area = "driver" });
            }           

            return View("login");
        }

        [HttpPost("login")]
        public IActionResult Login([FromForm] UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
                return View(userLoginViewModel);

            var user = _userService.GetByEmailAndPassword(userLoginViewModel.Email, userLoginViewModel.Password);

            if (user != null)
            {
                _session.CreateUserSession(user);
                if (user.Hierarchy == Repository.Enums.UserHierarchy.Administrador)
                    return RedirectToAction("Index", "Home", new { area = "Administrator" }); 
                
                if (user.Hierarchy == Repository.Enums.UserHierarchy.Guarda)
                    return RedirectToAction("Index", "Home", new { area = "Guard" });
                
                if (user.Hierarchy == Repository.Enums.UserHierarchy.Motorista)
                    return RedirectToAction("Index", "Home", new { area = "Driver" });
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

                return RedirectToAction(nameof(Register));
            }

            var token = Guid.NewGuid();

            userRegisterViewModel.Token = token;
            userRegisterViewModel.HierarchyId = Repository.Enums.UserHierarchy.Motorista;

            var user = _userService.Insert(userRegisterViewModel);

            var confirmationLink = Url.Action("ConfirmEmail", "Login",
                new { id = user.Id, token }, Request.Scheme);

            var email = _email.SendEMail(user.Email, "Confirmação de email",
                @$"<p>Olá, {user.Name}, como você está?
                <br>
                Confirme seu cadastro <a href='{confirmationLink}'>aqui</a>
                <br>
                Caso você não seja redirecionado, acesse pelo link abaixo:
                <br>
                {confirmationLink}<p>", null);

            TempData["Confirm"] = "Enviamos um email para você confirmar o seu login e se juntar ao nosso sistema!!!";
            return View(nameof(ConfirmEmail));
        }

        [HttpGet("ConfirmEmail")]
        public IActionResult ConfirmEmail([FromQuery] int id, Guid token)
        {
            var user = _userService.GetById(id);

            if (user == null || user.Token != token)
                TempData["Confirm"] = "Não existe nenhum usuário referido!";

            else if (user.IsEmailConfirmed == true)
                TempData["Confirm"] = "O usuário já possui o link confirmado!";

            else if (user.TokenExpiredDate.TimeOfDay < DateTime.Now.TimeOfDay)
                TempData["Confirm"] = "O link foi espirado! Tente criar outra conta";

            else
            {
                TempData["Confirm"] = "O usuário foi confirmado!";
                _userService.UpdateVerifyEmail(user.Id);
            }

            return View(nameof(ConfirmEmail));
        }
    }
}