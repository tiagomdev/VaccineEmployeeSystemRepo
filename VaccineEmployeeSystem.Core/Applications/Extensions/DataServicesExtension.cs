using Microsoft.Extensions.DependencyInjection;
using VaccineEmployeeSystem.Core.Applications.Services.Employes;
using VaccineEmployeeSystem.Core.Interfaces.Services.Employees;

namespace VaccineEmployeeSystem.Core.Applications.Extensions
{
    public static class DataServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateEmployeeVaccinationService, CreateEmployeeVaccinationService>();
            services.AddScoped<IGetEmployeeVaccinationService, GetEmployeeVaccinationService>();

            return services;
        }
    }
}
