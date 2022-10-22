﻿using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
	[Area("Driver")]
    [Route("driver/map")]
    public class MapController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
