using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using AdoptApi.Enums;
using AdoptApi.Models.Interfaces;

namespace AdoptApi.Models;

public class Document : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public DocumentType Type { get; set; }
    [MaxLength(14)]
    public string Number { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    [IgnoreDataMember]
    public User User { get; set; }
}