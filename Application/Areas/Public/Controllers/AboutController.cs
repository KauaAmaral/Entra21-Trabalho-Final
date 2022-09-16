using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Public.Controllers
{
    [Area("Public")]
    [Route("sobre")]
    public class AboutController : Controller
    {
        public IActionResult Sobre()
        {
            return View("About");
        }
    }
}