using LibraryApp.Models;
using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;
[Route("api/role")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
    [HttpPost("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody]AddRoleDTO roleDto)
    {
        await _roleService.Add(roleDto);
        return Ok();
    }

    [HttpGet("getAll")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAll()
    {
        var result = _roleService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _roleService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update([FromBody] AddRoleDTO roleDto)
    {
        _roleService.Update(roleDto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _roleService.Delete(id);
        return Ok();
    }
}