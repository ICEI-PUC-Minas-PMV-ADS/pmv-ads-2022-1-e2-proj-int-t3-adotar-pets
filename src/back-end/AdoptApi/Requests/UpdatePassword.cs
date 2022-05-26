using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdatePassword
{
    [StringLength(12, MinimumLength = 8, ErrorMessage = "A nova senha deve possuir no mínimo 8 caracteres e no máximo 12.")]
    public string NewPassword { get; set; }
    [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação não são iguais")]
    public string ConfirmPassword { get; set; }
}