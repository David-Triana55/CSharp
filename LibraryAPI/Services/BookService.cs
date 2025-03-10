using System.Collections;
using Microsoft.EntityFrameworkCore;
public class BookService : IBookService
{
  LibraryContext _libraryContext;
  public BookService(LibraryContext context)
  {
    _libraryContext = context;
  }
  // lsitar libros
  public IEnumerable<Book> GetBooks()
  {
    return _libraryContext.Books.Include(b => b.Author).ToList();
  }



  // agregar libros
  public async Task Add(Book book)
  {
    await _libraryContext.Books.AddAsync(book);
    await _libraryContext.SaveChangesAsync();
  }

  // editar libros
  public async Task Edit(int id, Book book)
  {
    Book editBook = await _libraryContext.Books.FindAsync(id);

    if (editBook != null)
    {
      editBook.AuthorId = book.AuthorId;
      editBook.Title = book.Title;
      editBook.Genre = book.Genre;
      editBook.PublicationDate = book.PublicationDate;
      editBook.Status = book.Status;

      await _libraryContext.SaveChangesAsync();
    }
  }
  // eliminar libros
  public async Task Remove(int id)
  {
    Book editBook = await _libraryContext.Books.FindAsync(id);

    if (editBook != null)
    {
      _libraryContext.Books.Remove(editBook);
      await _libraryContext.SaveChangesAsync();
    }
  }
}

public interface IBookService
{
  IEnumerable<Book> GetBooks();
  Task Add(Book book);
  Task Edit(int idx, Book book);
  Task Remove(int idx);
}