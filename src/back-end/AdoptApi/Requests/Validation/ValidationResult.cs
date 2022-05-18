using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace AdoptApi.Requests.Validation;

public class ValidationError
{
    public string Key { get; set; }
    public ModelErrorCollection Errors { get; set; }
}

public class ValidationResult
{
    public string Message { get; }
    public Dictionary<string, string[]?> Errors { get; }

    public ValidationResult(ModelStateDictionary modelState)
    {
        Message = "Erro de validação.";
        Errors = modelState.Where(x => x.Value.Errors.Count > 0)
        .ToDictionary(
            m => m.Key,
            m => m.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
        );
    }
}