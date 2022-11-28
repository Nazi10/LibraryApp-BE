using System.Security.Claims;
using LibraryApp.Enumerations;
using LibraryApp.Models;
using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[Route("api/user")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("addUser")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] AddUserDTO userDto)
    {
        var email = HttpContext.User?.Claims?
            .Where(x => x.Type == ClaimTypes.Email).FirstOrDefault().Value;
        userDto.CreatedBy = email;
        await _userService.Add(userDto);
        return Ok();
    }

    [HttpGet("getAll")]
    [Authorize(Roles = "Admin,Author")]
    public IActionResult GetAll()
    {
        var result = _userService.GetAll();
        return Ok(result);
    }

    [HttpGet("getAuthors")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAuthors()
    {
        var result = _userService.GetAuthors();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _userService.GetById(id);
        return Ok(result);
    }

    [HttpPut("updateUser")]
    [Authorize(Roles = "Admin")]
    public IActionResult UpdateUser([FromBody] UpdateUserDTO userDto)
    {
        _userService.UpdateUser(userDto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _userService.Delete(id);
        return Ok();
    }
}