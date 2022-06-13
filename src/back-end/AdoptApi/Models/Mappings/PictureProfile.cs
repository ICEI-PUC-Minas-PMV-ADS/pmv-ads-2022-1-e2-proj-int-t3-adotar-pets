using AdoptApi.Models.Dtos;
using AdoptApi.Models.Mappings.Resolvers;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class PictureProfile : Profile
{
    public PictureProfile ()
    {
        CreateMap<Picture, PictureDto>().ForMember(p => p.Url, opt => opt.MapFrom<PictureResolver>());
    }
}