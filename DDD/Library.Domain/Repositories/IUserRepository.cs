namespace Library.Domain.Repositories;
using Library.Domain.Entities;

public interface IUserRepository
{
  Task<User?> GetByIdAsync(Guid id);
  Task AddAsync(User user);
}
