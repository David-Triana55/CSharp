namespace Library.Domain.Repositories;
using Library.Domain.Entities;

public interface IBookRepository
{
  Task<Book?> GetByIdAsync(Guid id);
  Task<IEnumerable<Book>> GetAllAsync();
  Task AddAsync(Book book);
  Task UpdateAsync(Book book);
}
