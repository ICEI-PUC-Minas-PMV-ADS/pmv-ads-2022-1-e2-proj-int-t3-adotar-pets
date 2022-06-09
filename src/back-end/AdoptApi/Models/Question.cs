using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Enums;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Question : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PetType PetType { get; set; }
    public bool IsActive { get; set; } = true;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
}