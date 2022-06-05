using AdoptApi.Attributes;
using AdoptApi.Attributes.Extensions;
using AdoptApi.Enums;
using AdoptApi.Models;
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
[Route("api/user/profile")]
[Authorize][ValidateRequest]

public class UserController : ControllerBase
{
    private UserService _userService;
    private ImageUploadService _imageUploadService;

    public UserController(UserRepository userRepository, PictureRepository pictureRepository, IConfiguration configuration, IActionContextAccessor actionContextAccessor)
    {
        _userService = new UserService(configuration, actionContextAccessor, userRepository);
        _imageUploadService = new ImageUploadService(configuration, actionContextAccessor, pictureRepository);
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<UserDto>> GetInfo()
    {
        return await _userService.GetInfo(User.Identity.GetUserId());
    }
    
    [HttpPut]
    [Route("")]
    public async Task<ActionResult<UserDto>> UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        return await _userService.UpdateInfo(User.Identity.GetUserId(), request);
    }

    [HttpPut]
    [Route("picture")]
    public async Task<ActionResult<PictureDto>> UpdateProfilePicture([FromForm] UpdateProfilePictureRequest request)
    {
        return await _imageUploadService.UploadOne(request.Picture, PictureType.User);
    }


    [HttpPut]
    [Route("password")]
    public async Task<ActionResult<UserDto>> UpdatePassword([FromBody] UpdatePassword request)
    {
        return await _userService.UpdatePassword(User.Identity.GetUserId(), request);
    }
}