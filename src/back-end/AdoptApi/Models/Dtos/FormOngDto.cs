namespace AdoptApi.Models.Dtos;

public class FormOngDto
{
    public int Id { get; set; }
    public int TotalScore { get; set; } = 100;
    public bool IsFinished { get; set; } = false;
    public DateTime CreatedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int PetId { get; set; }
    public Pet Pet { get; set; }

    public List<Answer> Answers { get; set; }

}