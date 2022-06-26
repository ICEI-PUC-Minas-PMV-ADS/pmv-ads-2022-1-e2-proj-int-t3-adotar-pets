using AdoptApi.Attributes;
using AdoptApi.Attributes.Extensions;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Services;
using AutoMapper;
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
    private ImageUploadService _imageUploadService;

    public UserController(UserRepository userRepository, PictureRepository pictureRepository, IConfiguration configuration, IActionContextAccessor actionContextAccessor, IMapper mapper)
    {
        _userService = new UserService(configuration, actionContextAccessor, userRepository, mapper);
        _imageUploadService = new ImageUploadService(configuration, actionContextAccessor, pictureRepository);
    }

    [HttpGet]
    [Route("profile")]
    public async Task<ActionResult<UserDto>> GetInfo()
    {
        return await _userService.GetInfo(User.Identity.GetUserId());
    }
    
    [HttpPut]
    [Route("profile")]
    public async Task<ActionResult<UserDto>> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        return await _userService.UpdateInfo(User.Identity.GetUserId(), request);
    }
    
    [HttpGet]
    [Route("profile/{userId}")]
    public async Task<ActionResult<UserDto>> GetProtectorProfile(int userId)
    {
        return await _userService.GetProtectorProfile(userId);
    }
    
    [HttpPut]
    [Route("profile/picture")]
    public async Task<ActionResult<UserDto>> UpdateProfilePicture([FromForm] UpdateProfilePictureRequest request)
    {
        return await _userService.UpdateProfilePicture(User.Identity.GetUserId(), request, _imageUploadService);
    }
    
    [HttpDelete]
    [Route("profile/picture")]
    public async Task<ActionResult<UserDto>> DeleteProfilePicture()
    {
        return await _userService.DeleteProfilePicture(User.Identity.GetUserId(), _imageUploadService);
    }
    

    [HttpPut]
    [Route("password")]
    public async Task<ActionResult<UserDto>> UpdatePassword([FromBody] UpdatePassword request)
    {
        return await _userService.UpdatePassword(User.Identity.GetUserId(), request);
    }
}