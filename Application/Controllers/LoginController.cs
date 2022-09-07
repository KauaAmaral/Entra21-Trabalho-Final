using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Entra21.CSharp.Area21.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;


namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login([FromForm] UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
                return View(userLoginViewModel);

            var user = _userService.GetByEmail(userLoginViewModel.Email);

            if (user != null)
            {
                if (userLoginViewModel.VerifyLogin(user.Password))
                    return RedirectToAction("Index");

                TempData["Message"] = "A senha não corresponde com o e-mail!!!";
            }

            TempData["Message"] = "Não existe um usuário com esse e-mail";
            return View();
        }
    }
}
