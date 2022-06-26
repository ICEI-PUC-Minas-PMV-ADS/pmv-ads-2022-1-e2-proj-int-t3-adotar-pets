using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using AdoptApi.Models.Interfaces;
using NetTopologySuite.Geometries;

namespace AdoptApi.Models;

public class Address : ITrackable, ISoftDeletable
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [StringLength(8)]
    public string ZipCode { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public Point Location { get; set; }
    public string City { get; set; }
    public int? Number { get; set; }
    public string? Complement { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
    public DateTime? DeletedOn { get; set; }
    [IgnoreDataMember]
    public User User { get; set; }
}