using AdoptApi.Models.Dtos;

namespace AdoptApi.Services.Dtos;

public class TokenDto
{
    public UserDto User { get; set; }
    public string Token { get; set; }
}