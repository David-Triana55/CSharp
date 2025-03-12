using System.Collections;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
public class BookService(LibraryContext context) : IBookService
{
  readonly LibraryContext _context = context;

  public async Task<IEnumerable<ResponseBookDto>> GetBooks()
  {
    return await _context.Books
    .Include(b => b.Author)
    .Select(b => new ResponseBookDto
    {
      Id = b.Id,
      AuthorId = b.AuthorId,
      Title = b.Title,
      Genre = b.Genre,
      PublicationDate = b.PublicationDate,
      Status = b.Status,
      Author = new ResponseAuthorDto
      {
        Id = b.Author.Id,
        Name = b.Author.Name,
        Nationality = b.Author.Nationality,
        Birthdate = b.Author.Birthdate
      }
    }).OrderBy(b => b.Id).ToListAsync();
  }

  public async Task<ResponseBookDto> GetBookId(int id)
  {
    bool existBook = await _context.Books.AnyAsync(b => b.Id == id);

    if (!existBook)
    {
      throw new Exception("Book doesn't exist");
    }

    return await _context.Books
      .Where(b => b.Id == id)
      .Include(b => b.Author)
      .Select(b => new ResponseBookDto
      {
        Id = b.Id,
        AuthorId = b.AuthorId,
        Title = b.Title,
        Genre = b.Genre,
        PublicationDate = b.PublicationDate,
        Status = b.Status,
        Author = new ResponseAuthorDto
        {
          Id = b.Author.Id,
          Name = b.Author.Name,
          Nationality = b.Author.Nationality,
          Birthdate = b.Author.Birthdate
        }
      }).FirstAsync();
  }

  public async Task<ResponseBookDto> CreateBook(CreateBookDto book)
  {
    bool existAuthor = await _context.Authors.AnyAsync(a => a.Id == book.AuthorId);

    if (!existAuthor)
    {
      throw new Exception("Author doesn't exist");
    }

    var bookAdd = new Book
    {
      AuthorId = book.AuthorId,
      Title = book.Title,
      Genre = book.Genre,
      PublicationDate = book.PublicationDate,
      Status = book.Status
    };

    await _context.Books.AddAsync(bookAdd);
    await _context.SaveChangesAsync();

    return await _context.Books.Where(b => b.Id == bookAdd.Id)
    .Include(b => b.Author)
    .Select(b => new ResponseBookDto
    {
      Id = b.Id,
      AuthorId = b.AuthorId,
      Title = b.Title,
      Genre = b.Genre,
      PublicationDate = b.PublicationDate,
      Status = b.Status,
      Author = new ResponseAuthorDto
      {
        Id = b.Author.Id,
        Name = b.Author.Name,
        Nationality = b.Author.Nationality,
        Birthdate = b.Author.Birthdate
      }
    }).FirstAsync();

  }

  public async Task UpdateBook(int id, UpdateBookDto book)
  {
    Book editBook = await _context.Books.FindAsync(id);

    if (editBook == null)
    {
      throw new Exception("Book doesn't exist");
    }
    editBook.AuthorId = book.AuthorId;
    editBook.Title = book.Title;
    editBook.Genre = book.Genre;
    editBook.PublicationDate = book.PublicationDate;
    editBook.Status = book.Status;

    await _context.SaveChangesAsync();
  }

  public async Task DeleteBook(int id)
  {
    Book editBook = await _context.Books.FindAsync(id);

    if (editBook == null)
    {
      throw new Exception("Book doesn't exist");
    }

    _context.Books.Remove(editBook);
    await _context.SaveChangesAsync();
  }
}

public interface IBookService
{
  Task<IEnumerable<ResponseBookDto>> GetBooks();
  Task<ResponseBookDto> GetBookId(int id);
  Task<ResponseBookDto> CreateBook(CreateBookDto book);
  Task UpdateBook(int idx, UpdateBookDto book);
  Task DeleteBook(int idx);
}