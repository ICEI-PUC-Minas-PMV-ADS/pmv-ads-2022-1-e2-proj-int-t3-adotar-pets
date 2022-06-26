using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AdoptApi.Requests;
using AutoMapper;
using Microsoft.VisualBasic.CompilerServices;

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

    public async Task<PetDto?> UpdatePetStatus(int userId, int petId, UpdatePetStatusRequest request)
    {
        try
        {
            var pet = await  _petRepository.GetPetByIdAndUserId(petId, userId);
            pet.IsActive = request.IsActive;
            
            pet = await _petRepository.UpdatePet(pet);
            return GetPetDto(pet);
        }
        catch (InvalidOperationException)
        {
            _modelState.AddModelError("Pet", "Pet não encontrado.");
            return null;
        }
    }
    
    public async Task<PetDto?> UpdatePetProfile(int userId, int petId, UpdatePetProfile request)
    {
        try
        {
            var pet = await _petRepository.GetPetByIdAndUserId(petId, userId);
            pet.Name = Utils.FieldUtils.VariableIsNull(request.Name) ? pet.Name : request.Name;
            pet.Description = Utils.FieldUtils.VariableIsNull(request.Descripition)
                ? pet.Description
                : request.Descripition;
            pet.Type = (PetType)(Utils.FieldUtils.VariableIsNull(request.Type) ? pet.Type : request.Type);
            pet.Gender = (PetGender)(Utils.FieldUtils.VariableIsNull(request.Gender) ? pet.Gender : request.Gender);
            pet.Size = (PetSize)(Utils.FieldUtils.VariableIsNull(request.Size) ? pet.Size : request.Size);
            pet.BirthDate = Utils.FieldUtils.VariableIsNull(request.BirthDate) ? pet.BirthDate : DateOnly.Parse(request.BirthDate);

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