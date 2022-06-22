using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class FormProfile : Profile
{
    public FormProfile()
    {
        CreateMap<Form, FormDto>();
        CreateMap<Form, FormProtectorDto>();
    }
}