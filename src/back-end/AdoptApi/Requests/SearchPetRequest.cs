using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;

namespace AdoptApi.Requests;

public class SearchPetRequest
{
    public PetType? Type { get; set; } 
    public PetGender? Gender { get; set; }
    public PetSize? Size { get; set; }
    public PetAge? Age { get; set; }
    [Range(1, 100, ErrorMessage = "A distância do filtro deve ser de 1 a 100 km.")]
    public int? DistanceInKm { get; set; }
}
