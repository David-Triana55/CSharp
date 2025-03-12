using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService service) : ControllerBase
{
  readonly IAuthorService _AuthorService = service;

  [HttpGet]
  [Authorize]
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await _AuthorService.GetAuthors();
      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [Authorize]
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      var response = await _AuthorService.GetAuthorId(id);
      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpPost]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Post(CreateAuthorDto author)
  {
    try
    {
      ResponseAuthorDto responseAuthor = await _AuthorService.CreateAuthor(author);
      return CreatedAtAction(nameof(GetById), new { id = responseAuthor.Id }, responseAuthor);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Put(int id, UpdateAuthorDto author)
  {
    try
    {
      await _AuthorService.UpdateAuthor(id, author);
      return Ok(new { message = "Author update sucessfully" });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      await _AuthorService.DeleteAuthor(id);
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

}