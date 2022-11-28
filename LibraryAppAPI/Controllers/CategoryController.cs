using System.Security.Claims;
using LibraryApp.Models;
using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[Route("api/category")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add([FromBody] AddCategoryDTO category)
    {
        var context = HttpContext;
        var email = context.User?.Claims?
            .Where(x => x.Type == ClaimTypes.Email).FirstOrDefault().Value;
        category.CreatedBy = email;
        await _categoryService.Add(category);
        return Ok();
    }

    [HttpGet("getAll")]
    [Authorize(Roles = "Admin,Author")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update([FromBody] AddCategoryDTO category)
    {
        _categoryService.Update(category);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _categoryService.Delete(id);
        return Ok();
    }
}