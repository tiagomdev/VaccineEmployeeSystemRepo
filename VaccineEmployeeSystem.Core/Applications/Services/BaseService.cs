using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using VaccineEmployeeSystem.Core.Exceptions;

namespace VaccineEmployeeSystem.Core.Applications.Services
{
    public class BaseService
    {
        protected readonly ILogger Logger;
        public BaseService(ILogger logger)
        {
            Logger = logger;
        }
        protected async Task ValidateModel<T1>(T1 model, AbstractValidator<T1> validator)
        {
            var validation = await validator.ValidateAsync(model);

            if (validation.IsValid is false)
                throw new ModelValidationException(validation);
        }
    }
}
