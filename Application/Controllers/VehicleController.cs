using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService,
            IWebHostEnvironment webHostEnvironment)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var vehicles = _vehicleService.GetAll();

            return Ok(vehicles);
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var vehicle = _vehicleService.GetById(id);
            
            return Ok(vehicle);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] VehicleRegisterViewModel vehicleRegisterViewModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var vehicle = _vehicleService.Register(vehicleRegisterViewModel);
            return Ok(vehicle);
        }
    }
}
