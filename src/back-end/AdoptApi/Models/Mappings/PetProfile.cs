using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class PetProfile : Profile
{
    public PetProfile()
    {
        CreateMap<Pet, PetDto>();
    }
}