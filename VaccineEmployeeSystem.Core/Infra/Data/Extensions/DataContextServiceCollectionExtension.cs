using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VaccineEmployeeSystem.Core.Infra.Data.Configurations;
using VaccineEmployeeSystem.Core.Infra.Data.Context;

namespace VaccineEmployeeSystem.Core.Infra.Data.Extensions
{
    public static class DataContextServiceCollectionExtension
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            var configuration = sp.GetService<DatabaseConfig>();

            services.AddDbContext<VaccineEmployeeDbContext>(options =>
                 options.UseSqlServer(configuration.ConnectionString)
                    .EnableSensitiveDataLogging());

            return services;
        }
    }
}
