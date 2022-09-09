﻿using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{

    [Route("vehicle")]
    public class VehicleController : Controller // TODO ControleVehicle Revisar
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult Index() =>
           View("Index");

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var vehicleType = GetVehicleType();

            ViewBag.VehicleType = GetVehicleType();

            var vehicleRegisterViewModel = new VehicleRegisterViewModel();

            return View(vehicleRegisterViewModel);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromForm] VehicleRegisterViewModel vehicleRegisterViewModel)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.VehicleType = GetVehicleType();

                return View(vehicleRegisterViewModel);
            }

            _vehicleService.Register(vehicleRegisterViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet("delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _vehicleService.Delete(id);

            return RedirectToAction("Index");
        }


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

        private List<string> GetVehicleType()
        {
            return Enum
                .GetNames<VehicleType>()
                .OrderBy(x => x)
                .ToList();
        }
    }
}
