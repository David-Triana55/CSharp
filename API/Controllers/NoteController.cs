using System.Text.Json;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// los controladores de la aplicación se encargan de llamar a los servicios
[ApiController]
[Route("/api/[controller]")]
public class NotesController : ControllerBase
{

  INoteService _noteService;
  public NotesController(INoteService service)
  {
    _noteService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_noteService.Get());
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Note note)
  {
    try
    {
      await _noteService.Create(note);
      return Ok(new { message = "Note created successfully" });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { error = "An error occurred while creating the Note", details = ex.Message });
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Note note)
  {
    try
    {
      await _noteService.Update(id, note);
      return RedirectToRoute(new { controller = "Notes", action = "get" });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { error = "An error occurred while updating the Note", details = ex.Message });

    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id)
  {
    try
    {
      bool deleted = await _noteService.Remove(id);
      if (!deleted)
      {
        return NotFound(new { error = "Note not found" });
      }

      return Ok(new { message = "Note deleted successfully" });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { error = "An error occurred while removing the Note", details = ex.Message });
    }
  }

}