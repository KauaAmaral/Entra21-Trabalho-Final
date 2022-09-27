using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/vehicle")]
    public class VehicleController : Controller // TODO ControleVehicle Revisar
    {
        private readonly IUserController _vehicleService;
        private readonly ISessionAuthentication _session;

        public VehicleController(
            IUserController vehicleService,
            ISessionAuthentication sessionAuthentication            
            )
        {
            _vehicleService = vehicleService;
            _session = sessionAuthentication;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            var vehicleType = GetVehicleType();

            ViewBag.VehicleType = GetVehicleType();

            var vehicleRegisterViewModel = new VehicleRegisterViewModel();

            return View(vehicleRegisterViewModel);
        }

        [HttpPost("register")] // TODO: Problema para salvar
        public IActionResult Register([FromForm] VehicleRegisterViewModel vehicleRegisterViewModel)
        {
            var user = _session.FindUserSession();

            if (user != null)
                vehicleRegisterViewModel.UserId = user.Id;
            else
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                ViewBag.VehicleType = GetVehicleType();

                return View(vehicleRegisterViewModel);
            }

            _vehicleService.Register(vehicleRegisterViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("update")]
        public IActionResult Update([FromQuery] int id)
        {
            var vehicle = _vehicleService.GetById(id);
            var vehicleType = GetVehicleType();
            var user = _session.FindUserSession();

            var vehicleUpdateViewMode = new VehicleUpdateViewModel
            {
                Id = vehicle.Id,
                LicensePlate = vehicle.LicensePlate,
                Model = vehicle.Model,
                //UserId = user.Id
            };

            ViewBag.VehicleType = vehicleType;

            return View(vehicleUpdateViewMode);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] VehicleUpdateViewModel vehicleUpdateViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.VehicleType = GetVehicleType();

                return View(vehicleUpdateViewModel);
            }

            _vehicleService.Update(vehicleUpdateViewModel);

            return RedirectToAction("Index");
        }


        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _vehicleService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet("")]
        public IActionResult GetAllById()
        {
            var user = _session.FindUserSession();

            if (user == null)
                return RedirectToAction("Index", "Home");

            var vehicles = _vehicleService.GetAllById(user.Id);

            return View("Vehicle/Index", vehicles);//TUDO Problema de rota
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromQuery] int id)
        {
            var vehicle = _vehicleService.GetById(id);
            return Ok(vehicle);
        }

        private List<string> GetVehicleType()
        {
            return Enum
                .GetNames<VehicleType>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
