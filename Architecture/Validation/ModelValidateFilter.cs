using legendary_rotary_phone.Architecture.Validation;
using Microsoft.AspNetCore.Mvc.Filters;

namespace legendary_rotary_phone.Architecture
{
    public class ModelValidateFilter : IActionFilter, IOrderedFilter
    {
        public int Order => 0;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new ModelValidationException(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
