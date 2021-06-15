using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using VaccineEmployeeSystem.Core.Exceptions;

namespace VaccineEmployeeSystem.Api.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is NotFoundException)
            {
                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
                context.ExceptionHandled = true;
            }
            else if (context.Exception is ModelValidationException || context.Exception is BusinessException)
            {
                context.Result = new ObjectResult(new { ErrorType = context.Exception.GetType(), Errors = context.Exception.Message })
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
