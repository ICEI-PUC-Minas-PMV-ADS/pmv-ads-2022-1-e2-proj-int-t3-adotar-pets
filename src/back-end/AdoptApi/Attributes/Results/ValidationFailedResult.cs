using AdoptApi.Requests.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AdoptApi.Attributes.Results;

public class ValidationFailedResult : ObjectResult
{
    public ValidationFailedResult(ModelStateDictionary modelState) : base(new ValidationResult(modelState))
    {
        StatusCode = StatusCodes.Status422UnprocessableEntity;
    }
}