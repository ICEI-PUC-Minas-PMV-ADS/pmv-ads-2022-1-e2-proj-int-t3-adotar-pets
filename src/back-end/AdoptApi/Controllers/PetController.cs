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

    public PetController(PetRepository petRepository, IActionContextAccessor actionContextAccessor, IMapper mapper)
    {
        _petService = new PetService(actionContextAccessor, petRepository, mapper);
    }
    
    [HttpPost]
    [Route("create")]
    [Authorize(Roles = nameof(UserType.Protector))]
    public async Task<ActionResult<PetDto>> AddPet([FromBody] CreatePetRequest request)
    {
        return await _petService.PetRegister(User.Identity.GetUserId(), request);
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
}