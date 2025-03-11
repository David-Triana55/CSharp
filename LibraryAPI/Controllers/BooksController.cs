using LibraryAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
  IBookService _bookService;
  public BooksController(IBookService service)
  {
    _bookService = service;
  }

  [HttpGet]
  [Authorize(Roles = "user")]
  [Authorize(Roles = "admin")]
  public IActionResult Get()
  {
    return Ok(_bookService.GetBooks());
  }

  [HttpPost]
  [Authorize(Roles = "admin")]
  public IActionResult Post(CreateBookDto book)
  {
    _bookService.Add(book);
    return Created();
  }

  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Put(int id, UpdateBookDto book)
  {
    await _bookService.Edit(id, book);
    return Ok(new { message = "Book update sucessfully" });
  }

  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]

  public async Task<IActionResult> Delete(int id)
  {
    await _bookService.Remove(id);
    return NoContent();
  }

}