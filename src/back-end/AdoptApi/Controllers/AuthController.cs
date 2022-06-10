using AdoptApi.Attributes;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Requests;
using AdoptApi.Services;
using AdoptApi.Services.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdoptApi.Controllers;

[ApiController]
[EnableCors]
[ValidateRequest]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private UserService _userService;

    public AuthController(UserRepository userRepository, IConfiguration configuration, IActionContextAccessor actionContextAccessor, IMapper mapper)
    {
        _userService = new UserService(configuration, actionContextAccessor, userRepository, mapper);
    }

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<TokenDto?>> Login([FromBody] UserLoginRequest request, [FromServices] TokenService tokenService)
    {
        return await _userService.Login(request, tokenService);
    }

    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<ActionResult<UserDto?>> Register([FromBody] CreateUserRequest request)
    {
        return await _userService.Register(request);
    }
}