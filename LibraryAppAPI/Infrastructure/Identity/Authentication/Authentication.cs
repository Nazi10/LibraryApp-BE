using LibraryApp.Infrastructure.Settings;
using LibraryApp.Models;
using LibraryApp.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryApp.Infrastructure.Identity.Authentication;

public class Authentication : IAuthentication
{
    private readonly JWTSettings _jwtSettings;
    private readonly IUserService _userService;

    public Authentication(IOptions<JWTSettings> jwtSettings, IUserService userService)
    {
        _jwtSettings = jwtSettings.Value;
        _userService = userService;
    }
    public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
    {
        var user = await VerifyLogin(request);
        JwtSecurityToken jwtSecurityToken = GenerateJWToken(user);
        AuthenticationResponse response = new()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            ExpirationTime = DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            Role = user.Role,
            Id = user.Id
        };
        return response;
    }

    private JwtSecurityToken GenerateJWToken(UserDTO user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken jwtSecurityToken = JwtToken(signingCredentials, user);
        return jwtSecurityToken;
    }

    private JwtSecurityToken JwtToken(SigningCredentials signingCredentials, UserDTO user)
        => new(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: Claims(user),
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
            );

    private static Claim[] Claims(UserDTO user)
    {
        return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Id", user.Id.ToString())
            };
    }

    private async Task<UserDTO> VerifyLogin(AuthenticationRequest request)
    {
        try
        {
            var user = _userService.GetByEmail(request.Email);
            bool verified = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (verified)
                return user;
            else
                throw new Exception("There was a problem logging in. Check your email and password!");
        }
        catch
        {
            throw new Exception("There was a problem logging in. Check your email and password!");

        }
    }
}
