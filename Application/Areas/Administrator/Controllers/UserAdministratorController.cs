using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [IsUserLogged]
    [IsAdministrator]
    [Area("Administrator")]
    [Route("/Administrator/Users/")]
    public class UserAdministratorController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISessionAuthentication _session;
        private readonly IGuardService _guardService;

        public UserAdministratorController(IUserService userService,
            ISessionAuthentication sessionAuthentication,
            IGuardService guardService)
        {
            _session = sessionAuthentication;
            _userService = userService;
            _guardService = guardService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        {
            var validator = new UserRegisterViewModelValidator();
            var result = validator.Validate(userRegisterViewModel);

            if (!result.IsValid)
                result.AddToModelState(ModelState);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var register = _userService.Insert(userRegisterViewModel);

            return Ok(new { status = register });
        }

            [HttpPost("update")]
        public IActionResult Update([FromForm] UserUpdateAdministratorViewModel userUpdateAdministratorViewModel)
        {
            var validator = new UserUpdateAdministratorViewModelValidator();
            var result = validator.Validate(userUpdateAdministratorViewModel);

            if (!result.IsValid)
                result.AddToModelState(ModelState);

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var atualizou = _userService.Update(userUpdateAdministratorViewModel);

            return Ok(new { status = atualizou });
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var delete = _userService.Delete(id);

            if (!delete)
                return NotFound();

            return Ok();
        }

        [HttpGet("getUserHierarchy")]
        public IActionResult GetUserHierarchy()
        {
            var hierarchy = Enum
                .GetNames<UserHierarchy>()
                .OrderBy(x => x)
                .Select(x => new
                {
                    Id = (int)(UserHierarchy)Enum.Parse(typeof(UserHierarchy), x),
                    Text = x
                })
                .ToList();

            return Ok(hierarchy);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var user = _userService.GetById(id);

            return Ok(user);
        }
    }
}
