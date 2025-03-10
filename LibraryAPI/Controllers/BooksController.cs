using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
  IBookService _bookService;
  public BooksController(IBookService service)
  {
    _bookService = service;
  }

  [HttpGet()]
  public IActionResult Get()
  {
    return Ok(_bookService.GetBooks());
  }

  [HttpPost()]
  public IActionResult Post(Book book)
  {
    _bookService.Add(book);
    return Created();
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Book book)
  {
    await _bookService.Edit(id, book);
    return Ok(new { message = "Book update sucessfully" });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    await _bookService.Remove(id);
    return NoContent();
  }

}