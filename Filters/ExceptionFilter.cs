using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using legendary_rotary_phone.architecture;
using System;

namespace legendary_rotary_phone_api.Filters
{
    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue;

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is RotaryException rotaryExc)
            {
                HandleRotaryException(context, rotaryExc);
            }
            else if (context.Exception is Exception exc)
            {
                HandleUnhandled(context, exc);
            }
            else
            {
                return;
            }

            context.ExceptionHandled = true;
        }

        void HandleRotaryException(ActionExecutedContext context, RotaryException exception)
        {
            context.Result = new ObjectResult(new
            {
                exception.Status,
                exception.Message,
                exception.Details
            })
            {
                StatusCode = exception.Status,
            };
        }

        void HandleUnhandled(ActionExecutedContext context, Exception exception)
        {
            context.Result = new ObjectResult(new
            {
                Status = 500,
                exception.Message,
                Details = exception.ToString()
            })
            {
                StatusCode = 500,
            };
        }
    }
}
