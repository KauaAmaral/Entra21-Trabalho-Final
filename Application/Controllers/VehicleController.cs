using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VehicleController(IVehicleService vehicleService,
            IWebHostEnvironment webHostEnvironment)
        {
            _vehicleService = vehicleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet("gallery")]
        public IActionResult Gallery()
        {
            var vehicles = _vehicleService.GetAll();

            ViewBag.PathServer = _webHostEnvironment.WebRootPath;

            return View(vehicles);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var vehicles 
        }

    }
}
