namespace Library.Infrastructure.Repositories;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
  private readonly LibraryDbContext _context;

  public UserRepository(LibraryDbContext context)
  {
    _context = context;
  }

  public async Task<User?> GetByIdAsync(Guid id)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
  }

  public async Task AddAsync(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
  }
}
