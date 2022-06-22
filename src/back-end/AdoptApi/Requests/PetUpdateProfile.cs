using AdoptApi.Enums;

namespace AdoptApi.Requests;

public class PetUpdateProfile
{
    public string Name { get; set; }
    public string Descripition { get; set; }
    public PetType Type { get; set; }
    public PetGender Gender { get; set; }
    public PetSize Size { get; set; }
    //public string BirthDate { get; set; }
    public bool IsActive { get; set; }
}