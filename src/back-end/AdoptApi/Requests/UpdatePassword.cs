using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdatePassword
{
    [Required(ErrorMessage = "A senha atual é obrigatória.")]
    public string CurrentPassword { get; set; }
    [Required(ErrorMessage = "A senha é obrigatória.")]
    [MinLength(8, ErrorMessage = "A senha deve possuir pelo menos 8 caracteres.")]
    public string NewPassword { get; set; }
    [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação não são iguais.")]
    public string ConfirmPassword { get; set; }
}