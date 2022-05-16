using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;
using AdoptApi.Utils;

namespace AdoptApi.Requests.Dtos;

public class DocumentRequestDto: IValidatableObject
{
    public DocumentType Type { get; set; }
    [Required(ErrorMessage = "O número do documento é obrigatório.")]
    [RegularExpression(@"^(\d{11}|\d{14})$", ErrorMessage = "Forneça um número de documento válido.")]
    public string Number { get; set; }

    

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        switch (Type)
        {
            case DocumentType.Cpf when !CpfCnpjUtils.IsCpf(Number):
                yield return new ValidationResult("CPF inválido.", new List<string> { nameof(Number) });
                break;
            case DocumentType.Cnpj when !CpfCnpjUtils.IsCnpj(Number):
                yield return new ValidationResult("CNPJ inválido.", new List<string> { nameof(Number) });
                break;
        }
    }
}