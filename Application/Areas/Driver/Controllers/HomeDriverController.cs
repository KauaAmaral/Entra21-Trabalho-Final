using Entra21.CSharp.Area21.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/Home")]
    public class HomeDriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
