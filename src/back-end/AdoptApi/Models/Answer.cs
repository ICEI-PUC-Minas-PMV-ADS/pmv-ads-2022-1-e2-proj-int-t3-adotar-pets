using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Answer : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public int Penalties { get; set; } = 0;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public int FormId { get; set; }
    public Form Form { get; set; }

    public int AlternativeId { get; set; }
    public Alternative Alternative { get; set; }
}