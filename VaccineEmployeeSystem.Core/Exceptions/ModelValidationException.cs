using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineEmployeeSystem.Core.Exceptions
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string message) : base(message)
        {
        }

        public ModelValidationException(ValidationResult validationResult) : base(GetErrorMessages(validationResult.Errors))
        {

        }

        static string GetErrorMessages(IList<ValidationFailure> errors)
        {
            var errorMessage = new StringBuilder();

            foreach (var item in errors)
                errorMessage.AppendLine(item.ErrorMessage);

            return errorMessage.ToString();
        }
    }
}
