using LibraryAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService service) : ControllerBase
{
  readonly IBookService _bookService = service;

  [HttpGet]
  [Authorize]
  public async Task<IActionResult> Get()
  {
    try
    {
      var books = await _bookService.GetBooks();
      return Ok(books);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpGet("{id}")]
  [Authorize]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      var books = await _bookService.GetBookId(id);
      return Ok(books);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpPost]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Post(CreateBookDto book)
  {
    try
    {
      ResponseBookDto responseBook = await _bookService.CreateBook(book);
      return CreatedAtAction(nameof(GetById), new { id = responseBook.Id }, responseBook);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpPut("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Put(int id, UpdateBookDto book)
  {
    try
    {
      await _bookService.UpdateBook(id, book);
      return Ok(new { message = "Book update sucessfully" });

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
      await _bookService.DeleteBook(id);
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

}