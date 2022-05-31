using AdoptApi.Requests.Dtos;

namespace AdoptApi.Requests;

public class UpdateProfileRequest
{
    public UserEditRequestDto User { get; set; }
}