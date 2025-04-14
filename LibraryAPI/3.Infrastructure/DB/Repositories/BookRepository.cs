namespace LibraryAPI.Infrastructure.Repositories;

using LibraryAPI.Domain.Common;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Exceptions;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure.DB.Data;
using LibraryAPI.Infrastructure.DB.Models;
using Microsoft.EntityFrameworkCore;

public class BookRepository(LibraryContext context) : IBookRepository
{
  private readonly LibraryContext _context = context;

  public async Task<IEnumerable<Book>> GetBooks()
  {
    var bookEntityList = await _context.Books.Include(b => b.Author).ToListAsync();

    var books = bookEntityList.Select(b =>
    {
      var book = new Book(
        new BookId(b.Id),
        new AuthorId(b.AuthorId),
        b.Title,
        b.Genre,
        b.PublicationDate,
        b.Status
      );

      book.Author = new Author(
        new AuthorId(b.Author.Id),
        b.Author.Name,
        b.Author.Nationality,
        b.Author.Birthdate
      );

      return book;
    }).ToList();

    return books;
  }

  public async Task<Book> GetBookId(BookId id)
  {
    bool existBook = await _context.Books.AnyAsync(b => b.Id == id.Value);

    if (!existBook)
    {
      throw new BookNotFoundException();
    }

    var bookEntity = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(b => b.Id == id.Value);

    var book = new Book(
      new BookId(bookEntity.Id),
      new AuthorId(bookEntity.AuthorId),
      bookEntity.Title,
      bookEntity.Genre,
      bookEntity.PublicationDate,
      bookEntity.Status
    );

    book.Author = new Author(
      new AuthorId(bookEntity.Author.Id),
      bookEntity.Author.Name,
      bookEntity.Author.Nationality,
      bookEntity.Author.Birthdate
    );

    return book;

  }

  public async Task<Book> CreateBook(Book book)
  {
    bool existBook = await _context.Books.AnyAsync(b => b.Id == book.Id.Value);

    if (existBook)
    {
      throw new BookAlreadyExistException();
    }

    var bookEntity = new BookEntity
    {
      Id = book.Id.Value,
      AuthorId = book.AuthorId,
      Title = book.Title,
      Genre = book.Genre,
      PublicationDate = book.PublicationDate,
      Status = book.Status,
    };

    await _context.Books.AddAsync(bookEntity);
    await _context.SaveChangesAsync();

    var bookSaved = await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == book.Id.Value);

    var domainBook = new Book(
      new BookId(bookSaved.Id),
      new AuthorId(bookSaved.AuthorId),
      bookSaved.Title,
      bookSaved.Genre,
      bookSaved.PublicationDate,
      bookSaved.Status
    );

    domainBook.Author = new Author(
      new AuthorId(bookSaved.Author.Id),
      bookSaved.Author.Name,
      bookSaved.Author.Nationality,
      bookSaved.Author.Birthdate
    );

    return domainBook;
  }

  public async Task UpdateBook(BookId id, Book book)
  {
    var editBook = await _context.Books.FindAsync(id.Value) ?? throw new BookNotFoundException();

    editBook.AuthorId = book.AuthorId;
    editBook.Title = book.Title;
    editBook.Genre = book.Genre;
    editBook.PublicationDate = book.PublicationDate;
    editBook.Status = book.Status;

    await _context.SaveChangesAsync();
  }
  public async Task DeleteBook(BookId id)
  {
    var editBook = await _context.Books.FindAsync(id.Value) ?? throw new BookNotFoundException();

    _context.Books.Remove(editBook);
    await _context.SaveChangesAsync();
  }

}