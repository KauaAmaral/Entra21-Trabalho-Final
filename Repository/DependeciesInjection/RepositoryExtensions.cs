using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Microsoft.Extensions.DependencyInjection;

namespace Entra21.CSharp.Area21.Repository.DependeciesInjection
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddScoped<IGuardRepository, GuardRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}
