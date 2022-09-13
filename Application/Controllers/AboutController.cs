using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Controllers
{
    [Route("sobre")]
    public class AboutController : Controller
    {
        public IActionResult Sobre()
        {
            return View("About");
        }
    }
}
