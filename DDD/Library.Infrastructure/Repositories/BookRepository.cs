namespace Library.Infrastructure.Repositories;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
  private readonly LibraryDbContext _context;

  public BookRepository(LibraryDbContext context)
  {
    _context = context;
  }

  public async Task<Book?> GetByIdAsync(Guid id)
  {
    return await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
  }

  public async Task<IEnumerable<Book>> GetAllAsync()
  {
    return await _context.Books.ToListAsync();
  }

  public async Task AddAsync(Book book)
  {
    await _context.Books.AddAsync(book);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(Book book)
  {
    _context.Books.Update(book);
    await _context.SaveChangesAsync();
  }
}
