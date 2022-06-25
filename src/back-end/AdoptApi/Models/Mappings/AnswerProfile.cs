using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<Answer, AnswerDto>();
    }
}