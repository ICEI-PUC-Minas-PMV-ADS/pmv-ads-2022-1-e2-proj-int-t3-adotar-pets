using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdoptApi.Repositories;
using AdoptApi.Requests.Dtos;
using AdoptApi.Requests;

namespace AdoptApi.Services;

public class PetService
{
    private readonly ModelStateDictionary _modelState;
    private PetRepository _petRepository;

    public PetService(IActionContextAccessor actionContextAccessor, PetRepository repository)
    {
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _petRepository = repository;
    }


    private static PetDto GetPetDto(Pet pet)
    {
        return new PetDto
        {
            Name = pet.Name,
            Type = pet.Type,
            Gender = pet.Gender,
            BirthDate = pet.BirthDate,
            Size = pet.Size,
            MinScore = pet.MinScore,
            Needs = pet.Needs
        };
    }
    public async Task<PetDto?> GetPetInfo(int petId)
    {
        try
        {
            var pet = await _petRepository.GetPetById(petId);
            return GetPetDto(pet);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }


public async Task<PetDto?> PetRegister(CreatePetRequest request)
{
    var petDto = request.Pet;
    var pet = new Pet { Name = petDto.Name, Type = petDto.Type, Gender = petDto.Gender, BirthDate = DateOnly.ParseExact(petDto.BirthDate, "yyyy-MM-dd"), Size = petDto.Size, MinScore = petDto.MinScore};
    
   var createdPet = await _petRepository.CreatePet(pet);
    return GetPetDto(createdPet);
}

}