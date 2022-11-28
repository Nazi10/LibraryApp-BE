using System.Security.Claims;
using LibraryApp.Enumerations;
using LibraryApp.Models;
using LibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Controllers;

[Route("api/book")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpPost("add")]
    [Authorize(Roles = "Admin, Author")]
    public async Task<IActionResult> Add([FromForm] AddBookDTO bookDto)
    {
        var context = HttpContext;
        var userRole = context.User?.Claims?
            .Where(a => a.Type == ClaimTypes.Role).FirstOrDefault().Value;
        var email = context.User?.Claims?
            .Where(x => x.Type == ClaimTypes.Email).FirstOrDefault().Value;
        bookDto.CreatedBy = email;
        if (userRole == UserRole.Author.ToString())
        {
            var authorId = context.User?.Claims?
                .Where(a => a.Type.Equals("Id")).FirstOrDefault().Value;
            bookDto.AuthorId = Guid.Parse(authorId);

        }
        await _bookService.Add(bookDto);    
        return Ok();
    }

    [HttpGet("getAll")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAll()
    {
        var result = _bookService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _bookService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Roles = "Admin,Author")]
    public async Task<IActionResult> Update([FromForm] AddBookDTO bookDto)
    {
        await _bookService.Update(bookDto);
        return Ok();
    }

    [HttpDelete("delete/{id}")]
    [Authorize(Roles = "Admin,Author")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        _bookService.Delete(id);
        return Ok();
    }
    [HttpGet("author/{id}")]
    [Authorize(Roles = "Admin,Author")]
    public IActionResult GetByAuthorId([FromRoute] Guid id)
    {
        var result = _bookService.GetByAuthorId(id);
        return Ok(result);
    }
}