using legendary_rotary_phone.Architecture.ExceptionHandling;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace legendary_rotary_phone.Architecture.Validation
{
    public class ModelValidationException : HttpResponseException
    {
        public ModelValidationException(ModelStateDictionary dict)
        {
            Description = $"Validation errors occured: {string.Join("\n", dict.Select(pair => $"{pair.Key}- {pair.Value}"))}";
            Status = 400;
        }
    }
}
