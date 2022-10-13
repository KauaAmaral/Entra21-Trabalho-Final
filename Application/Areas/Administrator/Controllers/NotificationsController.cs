using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet("update")]
        //public IActionResult Update([FromQuery] int id)
        //{
        //    var vehicle = _vehicleService.GetById(id);
        //    var vehicleType = GetVehicleType();
        //    var user = _session.FindUserSession();

        //    var vehicleUpdateViewMode = new VehicleUpdateViewModel
        //    {
        //        Id = vehicle.Id,
        //        LicensePlate = vehicle.LicensePlate,
        //        Model = vehicle.Model,
        //        Type = vehicle.Type
        //    };

        //    ViewBag.VehicleType = vehicleType;

        //    return View(vehicleUpdateViewMode);
        //}

        //[HttpPost("update")]
        //public IActionResult Update([FromForm] VehicleUpdateViewModel vehicleUpdateViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.VehicleType = GetVehicleType();

        //        return View(vehicleUpdateViewModel);
        //    }

        //    _vehicleService.Update(vehicleUpdateViewModel);

        //    return RedirectToAction("Index");
        //}


        //[HttpGet("delete")]
        //public IActionResult Delete([FromQuery] int id)
        //{
        //    _vehicleService.Delete(id);

        //    return RedirectToAction("Index");
        //}
    }
}
