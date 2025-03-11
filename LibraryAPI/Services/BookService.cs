using System.Collections;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using Microsoft.EntityFrameworkCore;
public class BookService : IBookService
{
  readonly LibraryContext _context;
  public BookService(LibraryContext context)
  {
    _context = context;
  }
  // lsitar libros
  public IEnumerable<Book> GetBooks()
  {
    return _context.Books.Include(b => b.Author).ToList();
  }

  // agregar libros
  public async Task Add(CreateBookDto book)
  {
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
  }

  // editar libros
  public async Task Edit(int id, UpdateBookDto book)
  {
    Book editBook = await _context.Books.FindAsync(id);

    if (editBook != null)
    {
      editBook.AuthorId = book.AuthorId;
      editBook.Title = book.Title;
      editBook.Genre = book.Genre;
      editBook.PublicationDate = book.PublicationDate;
      editBook.Status = book.Status;

      await _context.SaveChangesAsync();
    }
  }
  // eliminar libros
  public async Task Remove(int id)
  {
    Book editBook = await _context.Books.FindAsync(id);

    if (editBook != null)
    {
      _context.Books.Remove(editBook);
      await _context.SaveChangesAsync();
    }
  }
}

public interface IBookService
{
  IEnumerable<Book> GetBooks();
  Task Add(CreateBookDto book);
  Task Edit(int idx, UpdateBookDto book);
  Task Remove(int idx);
}