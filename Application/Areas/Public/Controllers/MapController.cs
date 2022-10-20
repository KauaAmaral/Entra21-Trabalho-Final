using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Public.Controllers
{
    [Area("Public")]
    [Route("public/map")]
    public class MapController : Controller
    {
        private readonly IPaymentService _paymentService;
        
        public MapController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getLocations")]
        public IActionResult GetLocations()
        {
            var locations = _paymentService.GetLocations();

            return Ok(locations);
        }
    }
}
