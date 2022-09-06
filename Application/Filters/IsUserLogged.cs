using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Entra21.CSharp.Area21.Application.Filters
{
    public class IsUserLogged : ActionFilterAttribute
    {
        public readonly ISessionAuthentication _sessionAuthentication;

        public IsUserLogged(ISessionAuthentication sessionAuthentication)
        {
            _sessionAuthentication = sessionAuthentication;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("userSession");

            if (_sessionAuthentication.FindUserSession() == null)
               context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                    
            base.OnActionExecuting(context);
        }
    }
}
