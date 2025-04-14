namespace LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;

public interface IBookRepository
{
  Task<IEnumerable<Book>> GetBooks();
  Task<Book> GetBookId(BookId id);
  Task<Book> CreateBook(Book book);
  Task UpdateBook(BookId id, Book book);
  Task DeleteBook(BookId id);

}
