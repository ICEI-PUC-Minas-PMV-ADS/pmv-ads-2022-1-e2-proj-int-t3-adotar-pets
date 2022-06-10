using AdoptApi.Models.Dtos;
using AutoMapper;

namespace AdoptApi.Models.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}