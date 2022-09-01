using Entra21.CSharp.Area21.RepositoryDataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Entra21.CSharp.Area21.Repository.DependenciesInjection
{
    public static class RepositoryExtensions
    {   
        public static IServiceCollection InsertEntityFramework(
               this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<ShortTermParkingContext>(options =>
            options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));

            return services;
        }
    }
}



