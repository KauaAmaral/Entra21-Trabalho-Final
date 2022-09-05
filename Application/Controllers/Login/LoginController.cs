using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Entra21.CSharp.Area21.Service.Services.Users;
using Microsoft.AspNetCore.Mvc;


namespace Entra21.CSharp.Area21.Application.Controllers.Login
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        //[HttpPost]
        //public IActionResult Login([FromForm] UserRegisterViewModel userRegisterViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(userRegisterViewModel);
        //    }

        //    var user = _userService.GetByEmail(userRegisterViewModel.Email);
        //}
    }
}
