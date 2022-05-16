using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;

namespace AdoptApi.Requests.Dtos;

public class UserRequestDto : BaseUserRequestDto, IValidatableObject
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "A data de nascimento/criação é obrigatória.")]
    [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Data de nascimento/criação inválida.")]
    public string BirthDate { get; set; }
    [EnumDataType(typeof(UserType), ErrorMessage = "O tipo de usuário deve ser 0 (Adotante) ou 1 (Protetor).")]
    public UserType Type { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        DateOnly birthDate;
        try
        {
            birthDate = DateOnly.ParseExact(BirthDate, "yyyy-MM-dd");
        }
        catch (FormatException)
        {
            birthDate = DateOnly.FromDateTime(DateTime.Now);
        }
        BirthDate = birthDate.ToString("yyyy-MM-dd");
        if (Type == UserType.Adopter && DateOnly.FromDateTime(DateTime.Now).Year - DateOnly.ParseExact(BirthDate, "yyyy-MM-dd").Year < 18)
        {
            yield return new ValidationResult("Um adotante deve ter mais de 18 anos.",
                new List<string> {nameof(BirthDate)});
        }
    }
}