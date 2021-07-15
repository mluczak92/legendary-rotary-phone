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
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(new
                {
                    Status = exception.Status,
                    Message = exception.Message,
                    Details = exception.Details
                })
                {
                    StatusCode = exception.Status,
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
