
using AdoptApi.Enums;

namespace AdoptApi.Models.Dtos;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; }   
    public PetType Type { get; set; }
    public PetGender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public PetSize Size { get; set; }
    public int MinScore { get; set; }
    public ICollection<Need> Needs { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}