using AdoptApi.Requests.Dtos;

namespace AdoptApi.Requests;

public class UpdateProfileRequest
{
    public UserProfileRequestDto User { get; set; }
}