using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Enums;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Breed : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BreedType Type { get; set; }
    public bool IsActive { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public List<Pet> Pets { get; set; }
}