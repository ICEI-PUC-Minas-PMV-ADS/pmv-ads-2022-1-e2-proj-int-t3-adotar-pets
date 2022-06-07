using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;

namespace AdoptApi.Requests.Dtos;

public class PetRequestDto : IValidatableObject
{
    [Required(ErrorMessage ="O nome do animal é obrigatório.")]
    public string Name { get; set; }
    [Required(ErrorMessage ="O tipo do animal é obrigatório.")]
    public PetType Type { get; set; }
    [Required(ErrorMessage ="O gênero do animal é obrigatório")]
    public PetGender Gender { get; set; }
    [Required(ErrorMessage ="A idade do animal é obrigatória, ainda que aproximada")]
    public string BirthDate { get; set; }
    [Required(ErrorMessage ="O porte do animal é obrigatório")]
    public PetSize Size { get; set; }
    [Required(ErrorMessage ="A pontuação para adoção do animal é obrigatório.(O MinScore é a pontuação mínima de requisitos que o candidato adotante deve ter para adotar este animal")]
    public int MinScore { get; set; }
    [Required(ErrorMessage ="A descrição do animal é obrigatória. Conte um pouco sobre o pet para que o adotante saiba um pouco mais sobre ele.")]
    public string Description { get; set; }
    public ICollection<Need> Needs { get; set; }      

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
            yield return new ValidationResult("O pet deve ter uma idade válida.",
                new List<string> {nameof(BirthDate)});
        }
        
        if (DateOnly.FromDateTime(DateTime.Now).CompareTo(birthDate) < 0)
        {
            yield return new ValidationResult("O pet deve ter mais de 0 anos.",
                new List<string> {nameof(BirthDate)});
        }
    }
}