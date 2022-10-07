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

        [HttpGet("Index")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterViewModel userRegisterViewModel)
        {
            var userRegister = _userService.InsertAdministrator(userRegisterViewModel);

            return Ok(userRegister);

            //ViewBag.UserHierarchy = GetUserHierarchy();

            //var userRegisterViewModel = new UserRegisterViewModel();

            //return View("register", userRegisterViewModel);
        }

        //[HttpPost("register")]
        //public IActionResult Register(UserRegisterViewModel userRegisterViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.UserHierarchy = GetUserHierarchy();

        //        return View("User/register", userRegisterViewModel);
        //    }

        //    if (_userService.VerifyEmails(userRegisterViewModel.Email) == false)
        //    {
        //        TempData["Message"] = "Já existe uma conta com esse email, tente novamente";

        //        ViewBag.UserHierarchy = GetUserHierarchy();

        //        return View("User/register");
        //    }

        //    _userService.InsertAdministrator(userRegisterViewModel);

        //    return Ok("Index");
        //}

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

            return View("update", userUpdateAdministratorViewMode);
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
