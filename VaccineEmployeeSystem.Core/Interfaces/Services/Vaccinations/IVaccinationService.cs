

using System;

namespace VaccineEmployeeSystem.Core.Interfaces.Services.Vaccinations
{
    public interface IVaccinationService
    {
        (DateTime FirstDoseDate, DateTime? SecondDoseDate) GetVaccinationDates();
    }
}
