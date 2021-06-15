using System;
using System.ComponentModel.DataAnnotations;
using VaccineEmployeeSystem.Core.Domain.Models.Vaccinations;

namespace VaccineEmployeeSystem.Core.Domain.Models.Employees
{
    public class EmployeeVaccination
    {
        [Key]
        public int Id { get; set; }

        public Guid EmployeeId { get; set; }

        public EVaccinationType VaccinationType { get; set; }

        public DateTime FirstDoseDate { get; set; }

        public DateTime? SecondDoseDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
