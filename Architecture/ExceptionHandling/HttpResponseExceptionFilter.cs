using legendary_rotary_phone.Architecture.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace legendary_rotary_phone.Architecture.ExceptionHandling
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue;

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ModelValidationException exception)
            {
                context.Result = new ObjectResult(exception.Description)
                {
                    StatusCode = exception.Status,
                };
            }
            else
            {
                context.Result = new ObjectResult(context.Exception.Message);
            }

            context.ExceptionHandled = true;
        }
    }
}
