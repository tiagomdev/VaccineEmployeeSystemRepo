using System;
using VaccineEmployeeSystem.Core.Domain.Models.Vaccinations;
using VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations;
using VaccineEmployeeSystem.Core.Applications.Services.Vaccinations;

namespace VaccineEmployeeSystem.Core.Applications.Factories
{
    public class VaccinationFactory
    {
        public static IVaccinationService CreateVaccinationService(EVaccinationType type, DateTime vaccinationDate)
        {
            switch (type)
            {
                case EVaccinationType.Coronavac:
                    return new CoronavacVaccinationService(vaccinationDate);
                case EVaccinationType.AstraZeneca:
                    return new AstraZenecaVaccinationService(vaccinationDate);
                case EVaccinationType.Janssen:
                    return new JanssenVaccinationService(vaccinationDate);
                case EVaccinationType.Pfizer:
                    return new PfizerVaccinationService(vaccinationDate);
                case EVaccinationType.SputnikV:
                    return new SputnikVaccinationService(vaccinationDate);
                default:
                    return default;
            }
        }
    }
}
