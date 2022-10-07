using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Entra21.CSharp.Area21.Application.Filters
{
    public class IsAdministrator : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session.GetString("userSession");

            var user = JsonConvert.DeserializeObject<User>(session);

            if (user.Hierarchy != Repository.Enums.UserHierarchy.Administrador)
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "area", "Public" }, { "controller", "Alert" }, { "action", "Administrator" } });
            base.OnActionExecuting(context);

        }
    }
}
