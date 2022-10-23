using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [IsUserLogged]
    [IsAdministrator]
    [Area("Administrator")]
    [Route("administrator/vehicle")]
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var vehicles = _vehicleService.GetAll();

            return Ok(vehicles);
        }
    }
}