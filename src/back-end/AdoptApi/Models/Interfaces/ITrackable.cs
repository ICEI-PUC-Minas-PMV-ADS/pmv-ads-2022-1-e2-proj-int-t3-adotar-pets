using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoptApi.Models.Interfaces;

public interface ITrackable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedOn { get; set; }
}