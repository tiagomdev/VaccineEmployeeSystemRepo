using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Applications.ViewModels.Employees;
using VaccineEmployeeSystem.Core.Interfaces.Services.Employees;

namespace VaccineEmployeeSystem.Controllers
{
    [ApiController]
    [Route("api/employees/{employeeId}/vaccinations")]
    public class EmployeeVaccinationController : ControllerBase
    {
        private readonly ICreateEmployeeVaccinationService _createEmployeeVaccinationService;
        private readonly IGetEmployeeVaccinationService _getEmployeeVaccinationService;

        public EmployeeVaccinationController(ICreateEmployeeVaccinationService createEmployeeVaccinationService,
            IGetEmployeeVaccinationService getEmployeeVaccinationService)
        {
            _createEmployeeVaccinationService = createEmployeeVaccinationService;
            _getEmployeeVaccinationService = getEmployeeVaccinationService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateEmployeeVaccination([FromRoute]Guid employeeId,
            [FromBody] CreateEmployeeVaccinationViewModel createEmployeeVaccinationViewModel,
            CancellationToken cancellationToken = default)
        {
            createEmployeeVaccinationViewModel.EmployeeId = employeeId;

            await _createEmployeeVaccinationService.CreateAsync(createEmployeeVaccinationViewModel, cancellationToken);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DetailEmployeeVaccinationViewModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateEmployeeVaccination([FromRoute] Guid employeeId,
            CancellationToken cancellationToken = default)
        {
            var result = await _getEmployeeVaccinationService.GetBy(employeeId, cancellationToken);

            return Ok(result);
        }
    }
}
