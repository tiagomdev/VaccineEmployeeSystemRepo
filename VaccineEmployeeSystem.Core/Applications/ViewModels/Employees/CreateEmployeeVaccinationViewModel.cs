using System;
using System.Text.Json.Serialization;
using VaccineEmployeeSystem.Core.Domain.Models.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.ViewModels.Employees
{
    public class CreateEmployeeVaccinationViewModel
    {
        [JsonIgnore]
        public Guid EmployeeId { get; set; }

        public EVaccinationType VaccinationType { get; set; }

        public DateTime VaccinationDate { get; set; }
    }
}
