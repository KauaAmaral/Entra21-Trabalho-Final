using Entra21.CSharp.Area21.Repository.Repositories.Guards;
using Entra21.CSharp.Area21.Repository.Repositories.Notifications;
using Entra21.CSharp.Area21.Repository.Repositories.Payments;
using Entra21.CSharp.Area21.Repository.Repositories.Users;
using Entra21.CSharp.Area21.Repository.Repositories.Vehicles;
using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace Entra21.CSharp.Area21.Repository.DependeciesInjection
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IGuardRepository, GuardRepository>();
            services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }

        public static IServiceCollection AddEntityFramework(this IServiceCollection services, ConfigurationManager configurationManager)
        {   
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                services.AddDbContext<ShortTermParkingContext>(options =>
                    options.UseSqlServer(configurationManager.GetConnectionString("SqlServerMac")));
            }
            else
            {
                services.AddDbContext<ShortTermParkingContext>(options => 
                    options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));
            }
            
            return services;
        }
    }
}