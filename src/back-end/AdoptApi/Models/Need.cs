using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Need : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public ICollection<Pet> Pets { get; set; }
}