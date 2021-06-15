using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Applications.ViewModels.Employees;
using VaccineEmployeeSystem.Core.Domain.Models.Employees;
using VaccineEmployeeSystem.Core.Exceptions;
using VaccineEmployeeSystem.Core.Interfaces.Services.Employees;

namespace VaccineEmployeeSystem.Core.Applications.Services.Employes
{
    public class GetEmployeeVaccinationService : BaseService, IGetEmployeeVaccinationService
    {
        private readonly IEmployeeRepository employeeRepository;
        public GetEmployeeVaccinationService(ILogger<GetEmployeeVaccinationService> logger,
            IEmployeeRepository employeeRepository) : base(logger)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<DetailEmployeeVaccinationViewModel> GetBy(Guid employeeId, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Get employee by id={employeeId}.");
            var employee = await employeeRepository.Query().Include(e => e.Vaccination)
                .FirstOrDefaultAsync(e => e.Id.Equals(employeeId), cancellationToken);
            if (employee is null)
                throw new NotFoundException("Employee not found.");
            if (employee.Vaccination is null)
                throw new NotFoundException("Not exist vaccination to employee");

            return new DetailEmployeeVaccinationViewModel(employee.Name, employee.Vaccination.VaccinationType,
                employee.Vaccination.FirstDoseDate, employee.Vaccination.SecondDoseDate);
        }
    }
}
