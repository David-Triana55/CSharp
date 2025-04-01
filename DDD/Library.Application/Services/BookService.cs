namespace Library.Application.Services;
using Library.Domain.Entities;
using Library.Domain.Repositories;

public class BookService
{
  private readonly IBookRepository _bookRepository;

  public BookService(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }

  public async Task<IEnumerable<Book>> GetAllBooksAsync()
  {
    return await _bookRepository.GetAllAsync();
  }

  public async Task<Book?> GetBookByIdAsync(Guid id)
  {
    return await _bookRepository.GetByIdAsync(id);
  }

  public async Task AddBookAsync(string title, string author, int availableCopies)
  {
    var book = new Book(title, author, availableCopies);
    await _bookRepository.AddAsync(book);
  }
}
