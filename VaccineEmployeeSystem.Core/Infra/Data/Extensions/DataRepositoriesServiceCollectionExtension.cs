using Microsoft.Extensions.DependencyInjection;
using VaccineEmployeeSystem.Core.Domain.Models.Employees;
using VaccineEmployeeSystem.Core.Infra.Data.Repositories.Employees;

namespace VaccineEmployeeSystem.Core.Infra.Data.Extensions
{
    public static class DataRepositoriesServiceCollectionExtension
    {
        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
