using System;
using VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.Services.Vaccinations
{
    public class JanssenVaccinationService : IVaccinationService
    {
        private DateTime vaccinationDate;
        public JanssenVaccinationService(DateTime vaccinationDate)
        {
            this.vaccinationDate = vaccinationDate;
        }

        public (DateTime FirstDoseDate, DateTime? SecondDoseDate) GetVaccinationDates()
        {
            var firstDoseDate = vaccinationDate;
            return (firstDoseDate, null);
        }
    }
}
