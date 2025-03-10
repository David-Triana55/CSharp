using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
  IAuthorService _AuthorService;
  public AuthorsController(IAuthorService service)
  {
    _AuthorService = service;
  }

  [HttpGet()]
  public IActionResult Get()
  {
    return Ok(_AuthorService.GetAuthors());
  }

  [HttpPost()]
  public IActionResult Post(Author author)
  {
    _AuthorService.Add(author);
    return Created();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Author author)
  {
    await _AuthorService.Edit(id, author);
    return Ok(new { message = "Author update sucessfully" });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _AuthorService.Remove(id);
    return NoContent();
  }

}