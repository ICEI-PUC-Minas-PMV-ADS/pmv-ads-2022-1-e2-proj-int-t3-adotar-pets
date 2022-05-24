using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class NeedProfile : Profile
{
    public NeedProfile()
    {
        CreateMap<Need, NeedDto>();
    }
}