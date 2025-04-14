namespace LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;

public interface IUserRepository
{
  Task<IEnumerable<User>> GetUsers();
  Task Register(User user);
  Task<User> GetByEmail(string email);
  Task DeleteUser(UserId id);
}
