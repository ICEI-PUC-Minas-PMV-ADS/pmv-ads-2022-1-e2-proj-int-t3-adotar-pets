using System.ComponentModel.DataAnnotations;
using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Requests.Dtos;

namespace AdoptApi.Requests;

public class CreatePetRequest 
{
    public PetRequestDto Pet { get; set; }    
    
}

