using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdoptApi.Requests;
using AutoMapper;

namespace AdoptApi.Services;

public class PetService
{
    private readonly ModelStateDictionary _modelState;
    private PetRepository _petRepository;
    private readonly IMapper _mapper;

    public PetService(IActionContextAccessor actionContextAccessor, PetRepository repository, IMapper mapper)
    {
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _petRepository = repository;
        _mapper = mapper;
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
            Needs = pet.Needs,
            Description = pet.Description
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

    public async Task<PetDto?> PetRegister(int userId, CreatePetRequest request)
    {
        var petDto = request.Pet;
        var pet = new Pet
        {
            UserId = userId,
            Name = petDto.Name, Description = petDto.Description, Type = petDto.Type, Gender = petDto.Gender,
            BirthDate = DateOnly.ParseExact(petDto.BirthDate, "yyyy-MM-dd"), Size = petDto.Size,
            MinScore = petDto.MinScore, IsActive = true
        };

        var createdPet = await _petRepository.CreatePet(pet);
        return GetPetDto(createdPet);
    }

    public async Task<List<NeedDto>> ListNeeds()
    {
        var needs = await _petRepository.GetAvailableNeeds();
        return _mapper.Map<List<Need>, List<NeedDto>>(needs);
    }

    public async Task<PetDto?> GetPetProfile(int petId)
    {
        try
        {
            var petProfile = await _petRepository.GetAvailablePet(petId);
            return GetPetDto(petProfile);
        } catch (InvalidOperationException)
        {
            _modelState.AddModelError("Pet", "Pet não existe ou não está ativo.");
            return null;
        }
    }
}