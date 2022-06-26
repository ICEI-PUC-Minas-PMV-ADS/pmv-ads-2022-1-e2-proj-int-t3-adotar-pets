using AdoptApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdatePetProfile //: IValidatableObject
{
    [MinLength(2, ErrorMessage = "O campo de nome deve possuir mais que 2 caracteres")]
    public string? Name { get; set; } = null;

    [StringLength(400, MinimumLength = 20,
        ErrorMessage = "O campo de descrição deve possuir no mínimo 20 caracteres e no máximo 400 caracteres")]
    public string? Descripition { get; set; } = null;

    public PetType? Type { get; set; } = null;
    public PetGender? Gender { get; set; } = null;
    public PetSize? Size { get; set; } = null;

    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Data de nascimento/criação inválida.")]
    public string? BirthDate { get; set; } = null;

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
}