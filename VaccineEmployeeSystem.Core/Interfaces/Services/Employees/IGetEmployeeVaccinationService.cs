using System;
using System.Threading;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Applications.ViewModels.Employees;

namespace VaccineEmployeeSystem.Core.Interfaces.Services.Employees
{
    public interface IGetEmployeeVaccinationService
    {
        Task<DetailEmployeeVaccinationViewModel> GetBy(Guid employeeId, CancellationToken cancellationToken = default);
    }
}
