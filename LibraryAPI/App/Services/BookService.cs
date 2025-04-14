namespace LibraryAPI.App.Services;
using LibraryAPI.App.DTOs;
using LibraryAPI.App.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Interfaces;

public class BookService(IBookRepository repository) : IBookService
{

  private readonly IBookRepository _repository = repository;

  public async Task<IEnumerable<ResponseBookDto>> GetBooks()
  {
    var books = await _repository.GetBooks();
    return books.Select(b => new ResponseBookDto
    {
      Id = b.Id.Value,
      AuthorId = b.AuthorId,
      Title = b.Title,
      Genre = b.Genre,
      PublicationDate = b.PublicationDate,
      Status = b.Status,
      Author = new ResponseAuthorDto
      {
        Id = b.Author.Id.Value,
        Name = b.Author.Name,
        Nationality = b.Author.Nationality,
        Birthdate = b.Author.Birthdate
      }
    }).OrderBy(b => b.Id).ToList();
  }

  public async Task<ResponseBookDto> GetBookId(BookId id)
  {
    var book = await _repository.GetBookId(id);

    return new ResponseBookDto
    {
      Id = book.Id.Value,
      AuthorId = book.AuthorId,
      Title = book.Title,
      Genre = book.Genre,
      PublicationDate = book.PublicationDate,
      Status = book.Status,
      Author = new ResponseAuthorDto
      {
        Id = book.Author.Id.Value,
        Name = book.Author.Name,
        Nationality = book.Author.Nationality,
        Birthdate = book.Author.Birthdate
      }
    };
  }

  public async Task<ResponseBookDto> CreateBook(CreateBookDto book)
  {
    Book bookCreated = await _repository.CreateBook(new Book(new AuthorId(book.AuthorId), book.Title, book.Genre, book.PublicationDate, book.Status));

    return new ResponseBookDto
    {
      Id = bookCreated.Id.Value,
      AuthorId = bookCreated.AuthorId,
      Title = bookCreated.Title,
      Genre = bookCreated.Genre,
      PublicationDate = bookCreated.PublicationDate,
      Status = bookCreated.Status,
      Author = new ResponseAuthorDto
      {
        Id = bookCreated.Author.Id.Value,
        Name = bookCreated.Author.Name,
        Nationality = bookCreated.Author.Nationality,
        Birthdate = bookCreated.Author.Birthdate
      }
    };
  }

  public async Task UpdateBook(BookId id, UpdateBookDto book)
  {
    await _repository.UpdateBook(id, new Book(new AuthorId(book.AuthorId), book.Title, book.Genre, book.PublicationDate, book.Status));
  }

  public async Task DeleteBook(BookId id)
  {
    await _repository.DeleteBook(id);
  }
}
