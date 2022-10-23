using Entra21.CSharp.Area21.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Guard.Controllers
{
    [IsUserLogged]
    [IsGuard]
    [Area("Guard")]
    [Route("guard/map")]
    public class MapController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}