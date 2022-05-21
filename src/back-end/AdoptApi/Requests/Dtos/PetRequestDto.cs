using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;

namespace AdoptApi.Requests.Dtos;

public class PetRequestDto 
{
    public string Name { get; set; }
    [Required(ErrorMessage ="O tipo do animal é obrigatório.")]
    public PetType Type { get; set; }
    [Required(ErrorMessage ="O gênero do animal é obrigatório")]
    public PetGender Gender { get; set; }
    [Required(ErrorMessage ="A idade do animal é obrigatória, ainda que aproximada")]
    public string BirthDate { get; set; }
    [Required(ErrorMessage ="O porte do animal é obrigatório")]
    public PetSize Size { get; set; }
    public int MinScore { get; set; }
    //public ICollection<Need> Needs { get; set; }

}