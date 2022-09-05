using Entra21.CSharp.Area21.Service.EntitiesMappings;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.Services;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.Services;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace Entra21.CSharp.Area21.Service.DependenciesInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IPaymentService, PaymentService>();
            //services.AddScoped<IGuardService, GuardService>();
            //services.AddScoped<INotificationService, NotificationService>();

            return services;
        }

        //TODO: Descomentar classe ServiceExtensions
        public static IServiceCollection AddEntitiesMapping(this IServiceCollection services)
        {
            services.AddScoped<IUserEntityMapping, UserEntityMapping>();
            //services.AddScoped<IVehicleMapping, VehicleMapping>();
            services.AddScoped<IPaymentEntityMapping, PaymentEntityMapping>();
            //services.AddScoped<IGuardMapping, GuardMapping>();
            //services.AddScoped<INotificationMapping, NotificationMapping>();

            return services;
        }
    }
}
