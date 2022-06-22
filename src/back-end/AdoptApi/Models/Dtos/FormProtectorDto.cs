namespace AdoptApi.Models.Dtos;

public class FormProtectorDto
{
    public int Id { get; set; }
    public int TotalScore { get; set; } = 100;
    public bool IsFinished { get; set; } = false;
    public DateTime CreatedOn { get; set; }

    public UserDto User { get; set; }

    public PetDto Pet { get; set; }

    public ICollection<AnswerDto> Answers { get; set; }

}