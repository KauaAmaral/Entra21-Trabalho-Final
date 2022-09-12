using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Authentication;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [IsUserLogged]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;

        public UserController(IUserService userService, ISessionAuthentication session)
        {
            _userService = userService;
            _session = session;
        }

        public IActionResult Index()
        {
            return View("Update");
        }

        [HttpGet("update")]
        public IActionResult Update()
        {
            var user = _session.FindUserSession();
            var userUpdateViewModel = new UserUpdateViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Cpf = user.Cpf,
                Email = user.Email,
                Phone = user.Phone,
            };

            return View(userUpdateViewModel);
        }
        
        [HttpPost("update")]
        public IActionResult Update([FromForm] UserUpdateViewModel userUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View(userUpdateViewModel);

            var update = _userService.Update(userUpdateViewModel);

            return View(nameof(Update));
        }

        [HttpGet("changePassword")]
        public IActionResult ChangePassword()
        {
            var viewModel = new UserChangePasswordViewModel
            {
                Id = _session.FindUserSession().Id
            };
            
            return View(viewModel);
        }


        [HttpPost("changePassword")]
        public IActionResult ChangePassword([FromForm] UserChangePasswordViewModel userChangePasswordViewModel)
        {
            if (!ModelState.IsValid)
                return View(userChangePasswordViewModel);

            var user = _session.FindUserSession();

            if (userChangePasswordViewModel.CurrentPassword.GetHash() != user.Password)
            {
                TempData["message"] = "Senha atual é diferente da digitada, tente novamente!";
                return View(nameof(ChangePassword));
            }

            _userService.UpdatePassword(userChangePasswordViewModel);

            return View(nameof(ChangePassword));
        }

        [HttpGet("disable")]
        public IActionResult Disable()
        {
            var user = _session.FindUserSession();

            _userService.Disable(user);
            _session.RemoveUserSession();

            return RedirectToAction("Index", "Login");
        }
    }
}
