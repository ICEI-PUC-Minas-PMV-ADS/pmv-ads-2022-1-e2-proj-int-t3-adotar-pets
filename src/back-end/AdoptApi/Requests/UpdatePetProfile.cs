using AdoptApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdatePetProfile : IValidatableObject
{
    [Required(ErrorMessage = "O nome do animal é obrigatório."), MinLength(2, ErrorMessage = "O nome do pet deve possuir mais que 2 caracteres.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "O tipo do animal é obrigatório.")]
    public PetType Type { get; set; }
    [Required(ErrorMessage = "O gênero do animal é obrigatório.")]
    public PetGender Gender { get; set; }
    [Required(ErrorMessage = "A idade aproximada do animal é obrigatória.")]
    public string BirthDate { get; set; }
    [Required(ErrorMessage = "O porte do animal é obrigatório.")]
    public PetSize Size { get; set; }
    [Required(ErrorMessage = "A pontuação para adoção do animal é obrigatória."), Range(10, 100, ErrorMessage = "A pontuação mínima deve ser de 10 a 100 pontos.")]
    public int MinScore { get; set; }
    [Required(ErrorMessage = "A descrição do animal é obrigatória. Conte um pouco sobre o pet para que o adotante saiba um pouco mais sobre ele."), StringLength(400, MinimumLength = 20, ErrorMessage = "O campo de descrição deve possuir no mínimo 20 caracteres e no máximo 400 caracteres")]
    public string Description { get; set; }
    public bool IsActive { get; set; }
    
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

        if (birthDate == null)
        {
            yield return new ValidationResult("O pet deve ter uma idade válida.", new List<string> { nameof(BirthDate) });
        }

        if (DateOnly.FromDateTime(DateTime.Now).CompareTo(birthDate) < 0)
        {
            yield return new ValidationResult("O pet deve ter mais de 0 anos.", new List<string> { nameof(BirthDate) });
        }
    }
}