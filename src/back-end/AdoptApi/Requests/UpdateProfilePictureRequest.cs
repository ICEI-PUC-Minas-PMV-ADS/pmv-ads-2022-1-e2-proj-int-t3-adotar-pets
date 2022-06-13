using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdateProfilePictureRequest
{
    [Required(ErrorMessage = "A imagem é obrigatória para a foto de perfil.")]
    public IFormFile Picture { get; set; }
}