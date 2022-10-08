using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Guards;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users.Validations;
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

        [HttpGet("register")]
        public IActionResult Register()
        {
            ViewBag.UserHierarchy = GetUserHierarchy();

            var userRegisterViewModel = new UserRegisterViewModel();

            return View("register", userRegisterViewModel);
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        {
            var validator = new UserRegisterViewModelValidator();
            var result = validator.Validate(userRegisterViewModel);

            if (!result.IsValid || !ModelState.IsValid)
            {
                ViewBag.UserHierarchy = GetUserHierarchy();

                return View("User/register", userRegisterViewModel);
            }

            var user = _userService.Insert(userRegisterViewModel);

            if (userRegisterViewModel.IdentificationId != null)
            {
                var guardRegisterViewModel = new GuardRegisterViewModel
                {
                    Cpf = user.Cpf,
                    IdentificationNumber = userRegisterViewModel.IdentificationId,
                    UserId = user.Id
                };

                _guardService.Register(guardRegisterViewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("update")]
        public IActionResult Update([FromQuery] int id)
        {
            var user = _userService.GetById(id);

            var userUpdateAdministratorViewModel = new UserUpdateAdministratorViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Cpf = user.Cpf,
                Email = user.Email,
                Hierarchy = user.Hierarchy
            };

            if (user.Hierarchy == UserHierarchy.Guarda)
            {
                var guard = _guardService.GetByUserId(user.Id);

                userUpdateAdministratorViewModel.IdentificationId = guard.IdentificationNumber;
            }

            ViewBag.UserHierarchy = GetUserHierarchy();

            return View("User/update", userUpdateAdministratorViewModel);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] UserUpdateAdministratorViewModel userUpdateAdministratorViewMode)
        {
            var validator = new UserUpdateAdministratorViewModelValidator();
            var result = validator.Validate(userUpdateAdministratorViewMode);

            if (!result.IsValid || !ModelState.IsValid)
            {
                ViewBag.UserHierarchy = GetUserHierarchy();

                return View("User/update", userUpdateAdministratorViewMode);
            }

            var user = _userService.UpdateAdministrator(userUpdateAdministratorViewMode);

            if (userUpdateAdministratorViewMode.IdentificationId != null)
            {
                var guardRegisterViewModel = new GuardRegisterViewModel
                {
                    Cpf = user.Cpf,
                    IdentificationNumber = userUpdateAdministratorViewMode.IdentificationId,
                    UserId = user.Id
                };

                _guardService.Register(guardRegisterViewModel);
            }
            else
            {
                var guard = _guardService.GetByUserId(user.Id);
                _guardService.Delete(guard.Id);
            }

            return RedirectToAction("Index");
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _userService.Delete(id);

            return RedirectToAction("Index");
        }
        private List<string> GetUserHierarchy()
        {
            return Enum
                .GetNames<UserHierarchy>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
