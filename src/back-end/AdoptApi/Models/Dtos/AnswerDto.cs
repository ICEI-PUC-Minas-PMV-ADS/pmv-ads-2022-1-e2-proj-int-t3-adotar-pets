namespace AdoptApi.Models.Dtos;

public class AnswerDto
{
    public int Id { get; set; }
    public int Penalties { get; set; }
    public AlternativeDto Alternative { get; set; }
}