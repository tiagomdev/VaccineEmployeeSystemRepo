using System;
using VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.Services.Vaccinations
{
    public class PfizerVaccinationService : IVaccinationService
    {
        private DateTime vaccinationDate;
        public PfizerVaccinationService(DateTime vaccinationDate)
        {
            this.vaccinationDate = vaccinationDate;
        }

        public (DateTime FirstDoseDate, DateTime? SecondDoseDate) GetVaccinationDates()
        {
            var firstDoseDate = vaccinationDate;
            var secondDoseDate = vaccinationDate.AddMonths(3);
            return (firstDoseDate, secondDoseDate);
        }
    }
}
