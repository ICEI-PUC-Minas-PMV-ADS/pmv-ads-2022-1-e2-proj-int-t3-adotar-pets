using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests.Dtos;

public class AddressEditRequestDto
{
    [Required(ErrorMessage = "O campo CEP é obrigatório.")]
    [RegularExpression(@"^(\d{8})$", ErrorMessage = "Forneça um CEP válido.")]
    public string ZipCode { get; set; }
    [StringLength(200,ErrorMessage = "Esse campo deve ter no máximo 200 caracteres")]
    public int? Number { get; set; }
    public string? Complement { get; set; }
}