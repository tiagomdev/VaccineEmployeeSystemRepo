using System;
using VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.Services.Vaccinations
{
    public class CoronavacVaccinationService : IVaccinationService
    {
        private DateTime vaccinationDate;
        public CoronavacVaccinationService(DateTime vaccinationDate)
        {
            this.vaccinationDate = vaccinationDate;
        }

        public (DateTime FirstDoseDate, DateTime? SecondDoseDate) GetVaccinationDates()
        {
            var firstDoseDate = vaccinationDate;
            var secondDoseDate = vaccinationDate.AddDays(14);
            return (firstDoseDate, secondDoseDate);
        }
    }
}
