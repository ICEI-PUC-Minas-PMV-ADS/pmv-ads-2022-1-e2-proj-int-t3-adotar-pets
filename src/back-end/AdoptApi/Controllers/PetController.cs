using AdoptApi.Attributes;
using AdoptApi.Attributes.Extensions;
using AdoptApi.Enums;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdoptApi.Controllers;

[ApiController]
[EnableCors]
[ValidateRequest]
[Route("api/pet")]
[Authorize]
public class PetController : ControllerBase
{
    private PetService _petService;
    private UserService _userService;
    private ImageUploadService _imageUploadService;
    private FormService _formService;

    public PetController(PetRepository petRepository, UserRepository userRepository, PictureRepository pictureRepository, FormRepository formRepository, IConfiguration configuration, IActionContextAccessor actionContextAccessor, IMapper mapper)
    {
        _petService = new PetService(actionContextAccessor, petRepository, mapper);
        _userService = new UserService(configuration, actionContextAccessor, userRepository, mapper);
        _imageUploadService = new ImageUploadService(configuration, actionContextAccessor, pictureRepository);
        _formService = new FormService(actionContextAccessor, formRepository, petRepository, mapper);
    }
    
    [HttpPost]
    [Route("create")]
    [Authorize(Roles = nameof(UserType.Protector))]
    public async Task<ActionResult<PetDto>> AddPet([FromForm] CreatePetRequest request)
    {
        return await _petService.PetRegister(User.Identity.GetUserId(), request, _imageUploadService);
    }

    [HttpPut]
    [Route("update/{petId}")]
    [Authorize(Roles = nameof(UserType.Protector))]
    public async Task<ActionResult<PetDto?>> UpdatePetProfile(int petId, [FromBody] UpdatePetProfile request)
    {
        return await _petService.UpdatePetProfile(User.Identity.GetUserId(), petId, request);
    }
    
    [HttpGet]
    [Route("needs")]
    public async Task<ActionResult<List<NeedDto>>> ListNeeds()
    {
        return await _petService.ListNeeds();
    }
    
    [HttpGet]
    [Route("profile/{petId}")]
    public async Task<ActionResult<PetDto>> GetPetProfile(int petId)
    {
        return await _petService.GetPetProfile(petId);
    }

    [HttpGet]
    [Route("")]
    [Authorize(Roles = nameof(UserType.Protector))]
    public async Task<ActionResult<List<PetDto>>> ListPets()
    {
        return await _petService.ListPets(User.Identity.GetUserId());
    }

    [HttpGet]
    [Route("search")]
    public async Task<ActionResult<List<PetDto?>>> SearchPets([FromQuery]SearchPetRequest search)
    {
        return await _petService.SearchPets(User.Identity.GetUserId(), search, _userService);
    }
    
    [HttpGet]
    [Route("forms/{petId}")]
    [Authorize(Roles = nameof(UserType.Protector))]
    public async Task<ActionResult<List<FormProtectorDto?>>> ListFormsByPetId(int petId)
    {
        return await _formService.ListFormsByPetId(User.Identity.GetUserId(), petId);
    }
}