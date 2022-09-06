using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("update")]
        public IActionResult Update()
        {
            return View(nameof(Update));
        }
        
        [HttpPost("update")]
        public IActionResult Update([FromForm] UserUpdateViewModel userUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return View(userUpdateViewModel);

            var update = _userService.Update(userUpdateViewModel);

            return Ok(nameof(Update));
        }
    }
}
