using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Administrator.Controllers
{
    [IsUserLogged]
    [IsAdministrator]
    [Area("Administrator")]
    [Route("/Administrator/Payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IVehicleService _vehicleService;
        public PaymentsController(IPaymentService paymentService,
                IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var payments = _paymentService.GetAll();

            var payment = new Payment
            {
                User = new User()
            };
            ViewBag.Payment = payment;

            return Ok(payments);
        }

        [HttpGet("details")]
        public IActionResult Details([FromQuery] int id)
        {
            var details = _paymentService.GetById(id);

            return Ok(details);
        }
    }
}