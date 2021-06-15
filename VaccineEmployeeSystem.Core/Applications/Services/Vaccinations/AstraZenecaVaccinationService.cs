using System;
using VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.Services.Vaccinations
{
    public class AstraZenecaVaccinationService : IVaccinationService
    {
        private DateTime vaccinationDate;
        public AstraZenecaVaccinationService(DateTime vaccinationDate)
        {
            this.vaccinationDate = vaccinationDate;
        }

        public (DateTime FirstDoseDate, DateTime? SecondDoseDate) GetVaccinationDates()
        {
            var firstDoseDate = vaccinationDate;
            var secondDoseDate = vaccinationDate.AddDays(12 * 7);
            return (firstDoseDate, secondDoseDate);
        }
    }
}
