using System.ComponentModel.DataAnnotations;

namespace AdoptApi.Requests;

public class AnswerFormRequest
{
    [Required(ErrorMessage = "É necessário informar a alternativa para o formulário.")]
    public int? AlternativeId { get; set; }
}