using Entra21.CSharp.Area21.Repository.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Entra21.CSharp.Area21.Service.Authentication
{
    public class SessionAuthentication : ISessionAuthentication
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionAuthentication(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void CreateUserSession(User user)
        {
            var userString = JsonConvert.SerializeObject(user);

            _httpContextAccessor.HttpContext.Session.SetString("userSession", userString);
        }

        public User FindUserSession()
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("userSession");

            if (string.IsNullOrEmpty(session))
                return null;

            return JsonConvert.DeserializeObject<User>(session);
        }

        public void RemoveUserSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("userSession");
        }
    }
}
