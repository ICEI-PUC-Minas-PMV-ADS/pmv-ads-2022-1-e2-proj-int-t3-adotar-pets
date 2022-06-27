using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests.Dtos;

public class AddressEditRequestDto
{
    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    [RegularExpression(@"^(\d{8})$", ErrorMessage = "Forneça um CEP válido.")]
    public string ZipCode { get; set; }
    public int? Number { get; set; }
    public string? Complement { get; set; }
}