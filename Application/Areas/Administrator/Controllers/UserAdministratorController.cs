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

        //[HttpGet("register")]
        //public IActionResult Register()
        //{
        //    ViewBag.UserHierarchy = GetUserHierarchy();

        //    var userRegisterViewModel = new UserRegisterViewModel();

        //    return View("register", userRegisterViewModel);
        //}

        //[HttpPost("register")]
        //public IActionResult Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        //{
        //    var validator = new UserRegisterViewModelValidator();
        //    var result = validator.Validate(userRegisterViewModel);

        //    if (!result.IsValid || !ModelState.IsValid)
        //    {
        //        ViewBag.UserHierarchy = GetUserHierarchy();

        //        return View("User/register", userRegisterViewModel);
        //    }

        //    var user = _userService.Insert(userRegisterViewModel);

        //    if (userRegisterViewModel.IdentificationId != null)
        //    {
        //        var guardRegisterViewModel = new GuardRegisterViewModel
        //        {
        //            Cpf = user.Cpf,
        //            IdentificationNumber = userRegisterViewModel.IdentificationId,
        //            UserId = user.Id
        //        };

        //        _guardService.Register(guardRegisterViewModel);
        //    }

        //    return RedirectToAction("Index");
        //}

        //[HttpGet("update")]
        //public IActionResult Update([FromQuery] int id)
        //{
        //    var user = _userService.GetById(id);

        //    var userUpdateAdministratorViewModel = new UserUpdateAdministratorViewModel
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Phone = user.Phone,
        //        Cpf = user.Cpf,
        //        Email = user.Email,
        //        Hierarchy = user.Hierarchy
        //    };

        //    if (user.Hierarchy == UserHierarchy.Guarda)
        //    {
        //        var guard = _guardService.GetByUserId(user.Id);

        //        userUpdateAdministratorViewModel.IdentificationId = guard.IdentificationNumber;
        //    }

        //    ViewBag.UserHierarchy = GetUserHierarchy();

        //    return View("User/update", userUpdateAdministratorViewModel);
        //}

        //[HttpPost("register")]
        //public IActionResult Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return UnprocessableEntity(ModelState);
        //}

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
