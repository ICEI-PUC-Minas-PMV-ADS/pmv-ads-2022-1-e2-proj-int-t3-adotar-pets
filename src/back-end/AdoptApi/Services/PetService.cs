using AdoptApi.Enums;
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

    public async Task<PetDto?> GetPetInfo(int protectorId, int petId)
    {
        try
        {
            var pet = await _petRepository.GetPetByIdAndUserId(petId, protectorId);
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

    public async Task<PetDto?> PetRegister(int userId, CreatePetRequest request, ImageUploadService imageUploadService)
    {
        var pet = new Pet
        {
            UserId = userId,
            Name = request.Name, Description = request.Description, Type = request.Type, Gender = request.Gender,
            BirthDate = DateOnly.ParseExact(request.BirthDate, "yyyy-MM-dd"), Size = request.Size,
            MinScore = request.MinScore, Pictures = new List<Picture>()
        };

        var validatedPet = await ValidatePet(pet, request.Needs);

        if (!validatedPet)
        {
            return null;
        }

        foreach (var picture in request.Pictures)
        {
            var petPicture = await imageUploadService.UploadOne(picture, PictureType.Pet);
            if (petPicture == null)
            {
                return null;
            }
            pet.Pictures.Add(petPicture);
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
            _modelState.AddModelError("Pet", "Pet não encontrado ou não está ativo.");
            return null;
        }
    }
    
    public async Task<List<PetDto?>> ListPets(int userId)
    {
        var pets = await _petRepository.GetRegisteredPets(userId);
        return _mapper.Map<List<Pet>, List<PetDto>>(pets);
    }

    public async Task<List<PetDto?>> SearchPets(int userId, SearchPetRequest search, UserService userService)
    {
        var user = await userService.GetUser(userId);
        if (user == null)
        {
            return new List<PetDto?>();
        }
        var pets = await _petRepository.GetFilteredPets(user, search);
        return _mapper.Map<List<Pet>, List<PetDto?>>(pets);
    }
    
    public async Task<PetDto?> UpdatePetProfile(int userId, int petId, UpdatePetProfile request)
    {
        try
        {
            var pet = await _petRepository.GetPetByIdAndUserId(petId, userId);
            pet.Name = Utils.FieldUtils.UpdateFieldOrUseDefault(request.Name, pet.Name);
            pet.Description = Utils.FieldUtils.UpdateFieldOrUseDefault(request.Description, pet.Description);
            pet.Type = Utils.FieldUtils.UpdateFieldOrUseDefault(request.Type, pet.Type);
            pet.Gender = Utils.FieldUtils.UpdateFieldOrUseDefault(request.Gender, pet.Gender);
            pet.Size = Utils.FieldUtils.UpdateFieldOrUseDefault(request.Size, pet.Size);
            pet.BirthDate = Utils.FieldUtils.UpdateFieldOrUseDefault(DateOnly.Parse(request.BirthDate), pet.BirthDate);
            pet.MinScore = Utils.FieldUtils.UpdateFieldOrUseDefault(request.MinScore, pet.MinScore);
            pet.IsActive = Utils.FieldUtils.UpdateFieldOrUseDefault(request.IsActive, pet.IsActive);
            
            pet = await _petRepository.UpdatePet(pet);
            return GetPetDto(pet);
        }
        catch (InvalidOperationException)
        {
            _modelState.AddModelError("Pet", "Pet não encontrado.");
            return null;
        }
    }
}