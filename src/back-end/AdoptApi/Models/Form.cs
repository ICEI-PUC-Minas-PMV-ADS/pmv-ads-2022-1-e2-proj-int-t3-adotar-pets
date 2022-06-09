using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Form : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public int TotalScore { get; set; } = 100;
    public bool IsFinished { get; set; } = false;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int PetId { get; set; }
    public Pet Pet { get; set; }

    public List<Answer> Answers { get; set; }
}