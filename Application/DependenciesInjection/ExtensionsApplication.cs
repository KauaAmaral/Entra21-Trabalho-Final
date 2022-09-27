using Newtonsoft.Json;

namespace Entra21.CSharp.Area21.Application.DependenciesInjection
{
    public static class ExtensionsApplication
    {
        public static IServiceCollection IncrementNewtonsoftJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
              x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}
