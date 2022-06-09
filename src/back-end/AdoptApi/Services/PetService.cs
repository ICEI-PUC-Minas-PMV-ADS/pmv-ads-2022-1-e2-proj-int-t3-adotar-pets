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

    private PetDto GetPetDto(Pet pet)
    {
        return _mapper.Map<Pet, PetDto>(pet);
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

    public async Task<bool> ValidatePet(Pet pet, int[]? needIds)
    {
        if (needIds == null) return _modelState.IsValid;
        
        var needs = await _petRepository.GetAvailableNeedsByIds(needIds);
        if (needs.Count != needIds.Length)
        {
            _modelState.AddModelError("Pet.Needs", "Uma ou mais necessidades informadas não existem.");
        }

        pet.Needs = needs;

        return _modelState.IsValid;
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

        var validatedPet = await ValidatePet(pet, petDto.Needs);

        if (!validatedPet)
        {
            return null;
        }
        
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
    
    public async Task<List<PetDto>> ListPets(int userId)
    {
        var pets = await _petRepository.GetRegisteredPets(userId);
        return _mapper.Map<List<Pet>, List<PetDto>>(pets);
    }
    
}