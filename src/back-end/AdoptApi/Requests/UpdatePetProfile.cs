using AdoptApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdatePetProfile //: IValidatableObject
{
    [MinLength(2,ErrorMessage = "O campo de nome deve possuir mais que 2 caracteres")]
    public string? Name { get; set; }
    [StringLength(400,MinimumLength = 20,ErrorMessage = "O campo de descrição deve possuir no mínimo 20 caracteres e no máximo 400 caracteres")]
    public string? Descripition { get; set; }
    public PetType Type { get; set; }
    public PetGender Gender { get; set; }
    public PetSize Size { get; set; }
    /*
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Data de nascimento/criação inválida.")]
    public string BirthDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        DateOnly? birthDate;
        try
        {
            birthDate = DateOnly.ParseExact(BirthDate, "yyyy-MM-dd");
        }
        catch (FormatException)
        {
            birthDate = null;
        }

        if (DateOnly.FromDateTime(DateTime.Now).CompareTo(birthDate) < 0)
        {
            yield return new ValidationResult("O pet deve ter mais de 0 anos.", new List<string> { nameof(BirthDate) });
        }
    }
    */
    //@TODO Verificar porque o birthDate tá gerando erro
    /*
    #0 13.51 /src/AdoptApi/Services/PetService.cs(65,45): error CS1503: Argument 1: cannot convert from 'System.DateOnly' to 'System.ReadOnlySpan<char>' [/src/AdoptApi/AdoptApi.csproj]
    #0 13.51 /src/AdoptApi/Services/PetService.cs(140,29): error CS0305: Using the generic method group 'UpdateFieldOrUseDefault' requires 1 type arguments [/src/AdoptApi/AdoptApi.csproj]
    #0 13.51 /src/AdoptApi/Services/PetService.cs(140,72): error CS1503: Argument 1: cannot convert from 'string' to '?' [/src/AdoptApi/AdoptApi.csproj]
    */

}