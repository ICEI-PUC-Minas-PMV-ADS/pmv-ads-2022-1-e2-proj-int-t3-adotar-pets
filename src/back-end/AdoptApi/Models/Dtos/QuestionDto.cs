namespace AdoptApi.Models.Dtos;

public class QuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<AlternativeDto> Alternatives { get; set; }
}