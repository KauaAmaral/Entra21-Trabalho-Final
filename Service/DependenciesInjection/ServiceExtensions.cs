using Entra21.CSharp.Area21.Service.Authentication;
using Entra21.CSharp.Area21.Service.Email;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Guards;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Payments;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Users;
using Entra21.CSharp.Area21.Service.EntitiesMappings.Vehicles;
using Entra21.CSharp.Area21.Service.Services.Guards;
using Entra21.CSharp.Area21.Service.Services.Notifications;
using Entra21.CSharp.Area21.Service.Services.Payments;
using Entra21.CSharp.Area21.Service.Services.Users;
using Entra21.CSharp.Area21.Service.Services.Vehicles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Entra21.CSharp.Area21.Service.DependenciesInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IGuardService, GuardService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ISessionAuthentication, SessionAuthentication>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            return services;
        }

        public static IServiceCollection AddEntitiesMapping(this IServiceCollection services)
        {
            services.AddScoped<IUserEntityMapping, UserEntityMapping>();
            services.AddScoped<IVehicleEntityMapping, VehicleEntityMapping>();
            services.AddScoped<IPaymentEntityMapping, PaymentEntityMapping>();
            services.AddScoped<IGuardEntityMapping, GuardEntityMapping>();
            services.AddScoped<INotificationEntityMapping, NotificationEntityMapping>();

            return services;
        }
    }
}