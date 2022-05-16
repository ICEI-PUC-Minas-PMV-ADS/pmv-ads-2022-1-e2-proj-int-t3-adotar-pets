using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Enums;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Picture : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public PictureType Type { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public ICollection<Pet> Pets { get; set; }
}