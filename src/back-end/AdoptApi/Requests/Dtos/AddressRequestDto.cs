using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests.Dtos;

public class AddressRequestDto
{
    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    [RegularExpression(@"^(\d{8})$", ErrorMessage = "Forneça um CEP válido.")]
    public string ZipCode { get; set; }
}