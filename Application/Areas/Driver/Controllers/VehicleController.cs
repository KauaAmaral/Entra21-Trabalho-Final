using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [IsUserLogged]
    [IsDriver]
    [Area("Driver")]
    [Route("driver/vehicle")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly ISessionAuthentication _session;

        public VehicleController(
            IVehicleService vehicleService,
            ISessionAuthentication sessionAuthentication
            )
        {
            _vehicleService = vehicleService;
            _session = sessionAuthentication;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            ViewBag.VehicleType = GetVehicleType();

            var vehicleRegisterViewModel = new VehicleRegisterViewModel();

            return View(vehicleRegisterViewModel);
        }

        [HttpPost("register")]
        public IActionResult Register(VehicleRegisterViewModel vehicleRegisterViewModel)
        {
            var user = _session.FindUserSession();

            if (user != null)
                vehicleRegisterViewModel.UserId = user.Id;
           
            var vehicle = _vehicleService.Register(vehicleRegisterViewModel);

            return Ok(vehicle);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] VehicleUpdateViewModel vehicleUpdateViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            ViewBag.VehicleType = GetVehicleType();

            var atualizou = _vehicleService.Update(vehicleUpdateViewModel);

            return Ok(new { status = atualizou });
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            var delete = _vehicleService.Delete(id);

            if (!delete)
                return NotFound();

            return Ok();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var user = _session.FindUserSession();

            if (user == null)
                return RedirectToAction("Index", "Home");

            var vehicles = _vehicleService.GetByUserId(user.Id);

            return Ok(vehicles);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var vehicle = _vehicleService.GetById(id);

            return Ok(vehicle);
        }

        [HttpGet("getVehicleType")]
        public IActionResult GetVehicleType()
        {
            var type = Enum
                .GetNames<VehicleType>()
                .OrderBy(x => x)
                .Select(x => new
                {
                    Id = (int)(VehicleType)Enum.Parse(typeof(VehicleType), x),
                    Text = x
                })
                .ToList();

            return Ok(type);
        }

        [HttpGet("GetViewModelById")]
        public IActionResult GetViewModelById([FromQuery] int id)
        {
            var viewModel = _vehicleService.GetViewModelById(id);
            return Ok(viewModel);
        }
    }
}