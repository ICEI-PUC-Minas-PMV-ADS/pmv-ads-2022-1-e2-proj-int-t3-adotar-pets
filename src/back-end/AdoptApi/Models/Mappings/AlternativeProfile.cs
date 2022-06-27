using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class AlternativeProfile : Profile
{
    public AlternativeProfile()
    {
        CreateMap<Alternative, AlternativeDto>();
        CreateMap<Alternative, AlternativeProtectorDto>();
    }
}