using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Document, DocumentDto>();
    }
}