using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
  IAuthorService _AuthorService;
  public AuthorsController(IAuthorService service)
  {
    _AuthorService = service;
  }


  [HttpGet]
  [Authorize(Roles = "user")]
  [Authorize(Roles = "admin")]
  public IActionResult Get()
  {
    return Ok(_AuthorService.GetAuthors());
  }

  [HttpPost]
  [Authorize(Roles = "admin")]
  public IActionResult Post(CreateAuthorDto author)
  {
    _AuthorService.Add(author);
    return Created();
  }

  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Put(int id, UpdateAuthor author)
  {
    await _AuthorService.Edit(id, author);
    return Ok(new { message = "Author update sucessfully" });
  }

  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Delete(int id)
  {
    await _AuthorService.Remove(id);
    return NoContent();
  }

}