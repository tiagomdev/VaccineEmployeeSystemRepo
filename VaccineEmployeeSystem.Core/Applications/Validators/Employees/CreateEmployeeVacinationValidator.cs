using FluentValidation;
using System;
using VaccineEmployeeSystem.Core.Applications.ViewModels.Employees;

namespace VaccineEmployeeSystem.Core.Applications.Validators.Employees
{
    public class CreateEmployeeVacinationValidator : AbstractValidator<CreateEmployeeVaccinationViewModel>
    {
        public CreateEmployeeVacinationValidator()
        {
            RuleFor(e => e.EmployeeId).NotEmpty();
            RuleFor(e => e.VaccinationDate.Date).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date);
        }
    }
}
