using AdoptApi.Attributes;
using AdoptApi.Enums;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Services;
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

    public PetController(PetRepository petRepository, IActionContextAccessor actionContextAccessor)
    {
        _petService = new PetService(actionContextAccessor, petRepository);
    }
    
    // @TODO listar necessidades do banco
    // [HttpGet]
    // [Route("needs")]
    // [Authorize(Roles = nameof(UserType.Protector))]
    // public async Task<ActionResult<List<NeedDto>>> ListNeeds()
    // {
    //     
    // }

    // @TODO cadastrar um pet
    // [HttpPost]
    // [Route("")]
    // [Authorize(Roles = nameof(UserType.Protector))]
    // public async Task<ActionResult<List<PetDto>>> AddPet()
    // {
    //     
    // }
    
    // @TODO editar um pet
    // [HttpPut]
    // [Route("")]
    // [Authorize(Roles = nameof(UserType.Protector))]
    // public async Task<ActionResult<List<PetDto>>> EditPet()
    // {
    //     
    // }
}