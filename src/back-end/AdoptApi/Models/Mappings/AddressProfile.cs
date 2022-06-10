using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<Address, AddressDto>();
    }
}