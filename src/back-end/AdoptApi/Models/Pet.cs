using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Enums;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Pet : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public PetType Type { get; set; }
    public PetGender Gender { get; set; }
    public PetSize Size { get; set; }
    public string Name { get; set; }
    public int MinScore { get; set; }
    [Column(TypeName = "text")]
    public string Description { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool IsActive { get; set; } = true;
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public ICollection<Picture> Pictures { get; set; }
    public ICollection<Need> Needs { get; set; }
}