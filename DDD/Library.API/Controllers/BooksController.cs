using Library.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
  private readonly BookService _bookService;

  public BooksController(BookService bookService)
  {
    _bookService = bookService;
  }

  [HttpGet]
  public async Task<IActionResult> GetAllBooks()
  {
    var books = await _bookService.GetAllBooksAsync();
    return Ok(books);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetBookById(Guid id)
  {
    var book = await _bookService.GetBookByIdAsync(id);
    if (book == null) return NotFound();

    return Ok(book);
  }

  [HttpPost]
  public async Task<IActionResult> AddBook([FromBody] CreateBookDto createBookDto)
  {
    await _bookService.AddBookAsync(createBookDto.Title, createBookDto.Author, createBookDto.AvailableCopies);
    return CreatedAtAction(nameof(GetBookById), new { id = createBookDto.Id }, createBookDto);
  }
}
