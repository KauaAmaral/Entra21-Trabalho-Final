﻿using Entra21.CSharp.Area21.Application.Filters;
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
        private readonly IUserService _paymentService;
        private readonly IUserController _vehicleService;
        public PaymentsController(IUserService paymentService, 
                IUserController vehicleService)
        {
            _vehicleService = vehicleService;
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var payments = _paymentService.GetAllPayments();

            return View("payments", payments);
        }
    }
}
