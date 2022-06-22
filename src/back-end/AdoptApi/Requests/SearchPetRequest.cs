using AdoptApi.Enums;

namespace AdoptApi.Requests;

public class SearchPetRequest
{
    public PetType? Type { get; set; } 
    public PetGender? Gender { get; set; }
    public PetSize? Size { get; set; }
    public PetAge? Age { get; set; }
}
