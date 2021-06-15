using System;
using VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.Services.Vaccinations
{
    public class SputnikVaccinationService : IVaccinationService
    {
        private DateTime vaccinationDate;
        public SputnikVaccinationService(DateTime vaccinationDate)
        {
            this.vaccinationDate = vaccinationDate;
        }

        public (DateTime FirstDoseDate, DateTime? SecondDoseDate) GetVaccinationDates()
        {
            var firstDoseDate = vaccinationDate;
            var secondDoseDate = vaccinationDate.AddDays(21);
            return (firstDoseDate, secondDoseDate);
        }
    }
}
