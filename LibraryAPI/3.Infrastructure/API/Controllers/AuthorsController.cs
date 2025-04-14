using LibraryAPI.App.DTOs;
using LibraryAPI.App.Interfaces;
using LibraryAPI.Domain.Entities.ValueObjects;
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
  public async Task<IActionResult> GetById(Guid id)
  {
    try
    {
      var response = await _AuthorService.GetAuthorId(new AuthorId(id));
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
  public async Task<IActionResult> Put(Guid id, UpdateAuthorDto author)
  {
    try
    {
      await _AuthorService.UpdateAuthor(new AuthorId(id), author);
      return Ok(new { message = "Author update sucessfully" });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Delete(Guid id)
  {
    try
    {
      await _AuthorService.DeleteAuthor(new AuthorId(id));
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

}