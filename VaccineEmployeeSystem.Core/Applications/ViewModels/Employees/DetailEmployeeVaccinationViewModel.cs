using System;
using VaccineEmployeeSystem.Core.Domain.Models.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.ViewModels.Employees
{
    public class DetailEmployeeVaccinationViewModel
    {
        public DetailEmployeeVaccinationViewModel(string employeeName, EVaccinationType vaccinationType,
            DateTime vaccinationFirstDoseDate, DateTime? vaccinationSecondDoseDate)
        {
            EmployeeName = employeeName;
            VaccinationType = vaccinationType;
            VaccinationFirstDoseDate = vaccinationFirstDoseDate;
            VaccinationSecondDoseDate = vaccinationSecondDoseDate;
        }

        public string EmployeeName { get; set; }

        public EVaccinationType VaccinationType { get; set; }

        public DateTime VaccinationFirstDoseDate { get; set; }

        public DateTime? VaccinationSecondDoseDate { get; set; }
    }
}
