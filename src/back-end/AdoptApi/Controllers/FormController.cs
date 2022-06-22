using AdoptApi.Attributes;
using AdoptApi.Attributes.Extensions;
using AdoptApi.Enums;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
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
[Route("api/form")]
[Authorize]

public class FormController : ControllerBase
{
    private FormService _formService;

    public FormController(FormRepository formRepository, PetRepository petRepository, IConfiguration configuration, IActionContextAccessor actionContextAccessor, IMapper mapper)
    {
        _formService = new FormService(actionContextAccessor, formRepository, petRepository, mapper);
    }

    [HttpGet]
    [Route("adopt/{petId:int}")]
    [Authorize(Roles = nameof(UserType.Adopter))]
    public async Task<ActionResult<FormDto?>> GetFormQuestion(int petId)
    {
        return await _formService.GetAdoptionProgress(User.Identity.GetUserId(), petId);
    }
    
    [HttpGet]
    [Route("{formId:int}")]
    [Authorize(Roles = nameof(UserType.Protector))]
    public async Task<ActionResult<FormProtectorDto?>> GetForm(int formId)
    {
        return await _formService.ViewFormApplication(User.Identity.GetUserId(), formId);
    }
}