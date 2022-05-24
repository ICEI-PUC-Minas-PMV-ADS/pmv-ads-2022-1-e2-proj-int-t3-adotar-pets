using AdoptApi.Attributes.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdoptApi.Attributes;

public class ValidateRequestAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new ValidationFailedResult(context.ModelState);
        }
    }
}