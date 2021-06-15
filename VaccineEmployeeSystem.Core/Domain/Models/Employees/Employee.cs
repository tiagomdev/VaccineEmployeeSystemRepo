using System;
using System.ComponentModel.DataAnnotations;
using VaccineEmployeeSystem.Core.Domain.Models.Vaccinations;

namespace VaccineEmployeeSystem.Core.Domain.Models.Employees
{
    public class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual EmployeeVaccination Vaccination { get; set; }

        public void ToVaccine(EVaccinationType vaccinationType, DateTime firstDoseDate,
            DateTime? secondDoseDate)
        {
            Vaccination = new EmployeeVaccination()
            {
                VaccinationType = vaccinationType,
                FirstDoseDate = firstDoseDate,
                SecondDoseDate = secondDoseDate
            };
        }
    }
}
