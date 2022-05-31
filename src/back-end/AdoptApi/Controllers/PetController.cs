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
    [Route("registerPet")]
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

    // @TODO editar um pet
    // [HttpPut]
    // [Route("")]
    // [Authorize(Roles = nameof(UserType.Protector))]
    // public async Task<ActionResult<List<PetDto>>> EditPet()
    // {
    //     
    // }
}