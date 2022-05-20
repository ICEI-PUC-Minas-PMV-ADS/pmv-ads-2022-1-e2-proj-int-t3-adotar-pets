using AdoptApi.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AdoptApi.Services;

public class PetService
{
    private readonly ModelStateDictionary _modelState;
    private PetRepository _petRepository;

    public PetService(IActionContextAccessor actionContextAccessor, PetRepository repository)
    {
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _petRepository = repository;
    }
    
    //@TODO implementar métodos com regra de negócio (Business Layer)
}