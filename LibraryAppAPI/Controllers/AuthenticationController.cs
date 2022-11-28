using LibraryApp.Infrastructure.Identity.Authentication;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthentication _authentication;

    public AuthenticationController(IAuthentication authentication)
    {
        _authentication = authentication;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest auth)
        => Ok(await _authentication.Authenticate(auth));
}
