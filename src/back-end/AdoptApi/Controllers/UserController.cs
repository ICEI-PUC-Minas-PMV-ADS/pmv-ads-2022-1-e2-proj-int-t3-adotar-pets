using AdoptApi.Attributes;
using AdoptApi.Attributes.Extensions;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdoptApi.Controllers;

[ApiController]
[EnableCors]
[ValidateRequest]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    private UserService _userService;

    public UserController(UserRepository userRepository, IConfiguration configuration, IActionContextAccessor actionContextAccessor)
    {
        _userService = new UserService(configuration, actionContextAccessor, userRepository);
    }

    [HttpGet]
    [Route("profile")]
    public async Task<ActionResult<UserDto>> GetInfo()
    {
        return await _userService.GetInfo(User.Identity.GetUserId());
    }

    //@TODO: chamar método de service
    [HttpPut]
    [Route("profile")]
    public async Task<ActionResult<UserDto>> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        return await _userService.UpdateInfo(User.Identity.GetUserId(), request);
    }
    
    // @TODO criar request e chamar service
    // [HttpPut]
    // [Route("password")]
    // public async Task<ActionResult<UserDto>> UpdatePassword([FromBody] UpdateProfileRequest request)
    // {
    // }
}