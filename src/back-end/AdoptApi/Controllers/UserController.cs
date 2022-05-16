using AdoptApi.Attributes.Extensions;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using AdoptApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AdoptApi.Controllers;

[ApiController]
[EnableCors]
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
    [Route("")]
    public async Task<ActionResult<UserDto>> GetInfo()
    {
        var user = await _userService.GetInfo(User.Identity.GetUserId());
        if (user == null)
        {
            return Unauthorized(new {User = "Usuário não encontrado."});
        }

        return user;
    }
}