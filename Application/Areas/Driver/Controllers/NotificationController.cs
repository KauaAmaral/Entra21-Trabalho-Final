using Entra21.CSharp.Area21.Application.Filters;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Entra21.CSharp.Area21.Application.Areas.Driver.Controllers
{
    [Area("Driver")]
    [IsUserLogged]
    [Route("driver/notification")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly IGuardService _guardService;

        public NotificationController(
            INotificationService notificationService,
            IGuardService guardService )
        {
            _notificationService = notificationService;
            _guardService = guardService;
        }
    }
}
