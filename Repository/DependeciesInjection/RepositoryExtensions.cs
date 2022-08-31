using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public static IServiceCollection AddEntityFramework(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<ShortTermParkingContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));

            return services;
        }
    }
}
