using System.Threading;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Applications.ViewModels.Employees;

namespace VaccineEmployeeSystem.Core.Interfaces.Services.Employees
{
    public interface ICreateEmployeeVaccinationService
    {
        Task CreateAsync(CreateEmployeeVaccinationViewModel createEmployeeVaccinationViewModel,
            CancellationToken cancellationToken = default);
    }
}
