using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class UpdatePassword
{
    
    public string CurrentPassword { get; set; }
    [MinLength(8,ErrorMessage = "A nova senha deve possuir no máximo 8 caracteres")]
    public string NewPassword { get; set; }
    [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação não são iguais")]
    public string ConfirmPassword { get; set; }
}