using System.ComponentModel.DataAnnotations;
using AdoptApi.Attributes;
using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Requests.Dtos;
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
public class PetController
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
        return await _petService.PetRegister(request);
    }
    
    [HttpGet]
    [Route("needs")]
    public async Task<ActionResult<List<NeedDto>>> ListNeeds()
    {
        return await _petService.ListNeeds();
    }
    
    // @TODO ver perfil do pet e checar se está ativo
    // [HttpGet]
    // [Route("profile/{petId}")]
    // public async Task<ActionResult<PetDto>> GetPetProfile(int petId)
    // {
    //     return await _petService.ListNeeds();
    // }

    // @TODO editar um pet
    // [HttpPut]
    // [Route("edit/{petId}")]
    // [Authorize(Roles = nameof(UserType.Protector))]
    // public async Task<ActionResult<PetDto>> EditPet(int petId)
    // {
    //     
    // }
}