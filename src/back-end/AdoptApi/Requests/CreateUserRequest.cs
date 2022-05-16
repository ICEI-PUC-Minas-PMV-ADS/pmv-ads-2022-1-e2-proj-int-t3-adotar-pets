using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;
using AdoptApi.Requests.Dtos;

namespace AdoptApi.Requests;

public class CreateUserRequest : IValidatableObject
{
    public UserRequestDto User { get; set; }
    public DocumentRequestDto Document { get; set; }
    public AddressRequestDto Address { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        switch (User.Type)
        {
            case UserType.Adopter when Document.Type != DocumentType.Cpf:
                yield return new ValidationResult("Um usuário adotante deve possuir um CPF.", new List<string> { "Document.Number" });
                break;
            case UserType.Protector when Document.Type != DocumentType.Cnpj:
                yield return new ValidationResult("Um usuário protetor deve possuir um CNPJ.", new List<string> { "Document.Number" });
                break;
        }
    }
}