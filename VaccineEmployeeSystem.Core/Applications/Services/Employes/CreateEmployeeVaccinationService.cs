using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Applications.Validators.Employees;
using VaccineEmployeeSystem.Core.Applications.ViewModels.Employees;
using VaccineEmployeeSystem.Core.Domain.Models.Employees;
using VaccineEmployeeSystem.Core.Exceptions;
using VaccineEmployeeSystem.Core.Interfaces.Services.Employees;

namespace VaccineEmployeeSystem.Core.Applications.Services.Employes
{
    public class CreateEmployeeVaccinationService : BaseService, ICreateEmployeeVaccinationService
    {
        private readonly IEmployeeRepository employeeRepository;
        public CreateEmployeeVaccinationService(ILogger<CreateEmployeeVaccinationService> logger,
            IEmployeeRepository employeeRepository) : base(logger)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task CreateAsync(CreateEmployeeVaccinationViewModel createEmployeeVaccinationViewModel,
            CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Validate createEmployeeVaccinationViewModel...");
            await ValidateModel(createEmployeeVaccinationViewModel, new CreateEmployeeVacinationValidator());

            Logger.LogInformation($"Verify if employee with id={createEmployeeVaccinationViewModel.EmployeeId} exists.");
            var employee = await employeeRepository.Query().Include(e => e.Vaccination)
                .FirstOrDefaultAsync(e => e.Id.Equals(createEmployeeVaccinationViewModel.EmployeeId), cancellationToken);
            if (employee is null)
                throw new BusinessException("Employee to vaccine not exists.");
            if (employee.Vaccination is not null)
                throw new BusinessException("Employee already has been vaccined.");

            var vaccinationService = Factories.VaccinationFactory.CreateVaccinationService(createEmployeeVaccinationViewModel.VaccinationType,
                createEmployeeVaccinationViewModel.VaccinationDate);
            var vacinationDoseDates = vaccinationService.GetVaccinationDates();
            Logger.LogInformation("Vaccine employee...");
            employee.ToVaccine(createEmployeeVaccinationViewModel.VaccinationType, vacinationDoseDates.FirstDoseDate,
                vacinationDoseDates.SecondDoseDate);
            employeeRepository.Update(employee);
            await employeeRepository.SaveChangeAsync(cancellationToken);
        }
    }
}
