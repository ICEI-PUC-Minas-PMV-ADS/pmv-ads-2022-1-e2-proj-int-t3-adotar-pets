using System.ComponentModel.DataAnnotations.Schema;
using AdoptApi.Enums;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class User : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public UserType Type { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool IsActive { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }

    public int DocumentId { get; set; }
    public Document Document { get; set; }

    public int AddressId { get; set; }
    public Address Address { get; set; }
    public List<Pet> Pets { get; set; }
    
    public int? PictureId { get; set; }
    public Picture? Picture { get; set; }
}