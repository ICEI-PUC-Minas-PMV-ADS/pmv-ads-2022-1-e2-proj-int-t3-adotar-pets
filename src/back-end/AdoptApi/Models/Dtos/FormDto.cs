namespace AdoptApi.Models.Dtos;

public class FormDto
{
    public int Id { get; set; }
    public QuestionDto? CurrentQuestion { get; set; }
    public bool IsFinished { get; set; } = false;
    public int TotalQuestions { get; set; } = 0;
    public int QuestionsLeft { get; set; } = 0;
    public double Percentage { get; set; }
}