namespace LibraryAPI.App.Interfaces;
using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Entities.ValueObjects;

public interface IBookService
{
  Task<IEnumerable<ResponseBookDto>> GetBooks();
  Task<ResponseBookDto> GetBookId(BookId id);
  Task<ResponseBookDto> CreateBook(CreateBookDto book);
  Task UpdateBook(BookId id, UpdateBookDto book);
  Task DeleteBook(BookId id);
}