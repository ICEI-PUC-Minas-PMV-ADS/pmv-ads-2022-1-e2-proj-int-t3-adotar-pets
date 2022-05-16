using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AdoptApi.Models;
using Microsoft.IdentityModel.Tokens;

namespace AdoptApi.Services;

public class TokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Auth:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.PrimarySid, user.Id.ToString(), ClaimValueTypes.Integer),
                new(ClaimTypes.Role, user.Type.ToString())
            }),
            Expires = DateTime.Now.AddHours(5),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}