using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Alternative : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsActive { get; set; } = true;
    public int SmallSizePenalty { get; set; } = 0;
    public int MediumSizePenalty { get; set; } = 0;
    public int LargeSizePenalty { get; set; } = 0;
    public int BabyAgePenalty { get; set; } = 0;
    public int AdultAgePenalty { get; set; } = 0;
    public int SeniorAgePenalty { get; set; } = 0;
    public int MaleGenderPenalty { get; set; } = 0;
    public int FemaleGenderPenalty { get; set; } = 0;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    
    public int QuestionId { get; set; }
    public Question Question { get; set; }
}