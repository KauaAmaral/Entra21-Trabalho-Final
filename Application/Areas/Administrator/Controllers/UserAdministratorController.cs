using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Users;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
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

        public UserAdministratorController(IUserService userService, 
            ISessionAuthentication sessionAuthentication)
        {
            _session = sessionAuthentication;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return View("User/Index", users);
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            var userHierarchy = GetUserHierarchy();

            ViewBag.UserHierarchy = GetUserHierarchy();

            var userRegisterViewModel = new UserRegisterViewModel();

            return View("User/register", userRegisterViewModel);
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UserHierarchy = GetUserHierarchy();

                return View("User/register", userRegisterViewModel);
            }

            _userService.Insert(userRegisterViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("update")]
        public IActionResult Update([FromQuery] int id)
            {
            var user = _userService.GetById(id);
            var vehicleType = GetUserHierarchy();

            var userUpdateAdministratorViewMode = new UserUpdateAdministratorViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Phone = user.Phone,
                Cpf = user.Cpf,
                Email = user.Email,
                Hierarchy = user.Hierarchy
            };

            ViewBag.UserHierarchy = GetUserHierarchy();

            return View("User/update", userUpdateAdministratorViewMode);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] UserUpdateAdministratorViewModel userUpdateAdministratorViewMode)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UserHierarchy = GetUserHierarchy();

                return View("User/update", userUpdateAdministratorViewMode);
            }

            _userService.UpdateAdministrator(userUpdateAdministratorViewMode);

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
