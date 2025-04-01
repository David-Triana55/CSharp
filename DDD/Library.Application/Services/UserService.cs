namespace Library.Application.Services;
using Library.Domain.Entities;
using Library.Domain.Repositories;

public class UserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<User?> GetUserByIdAsync(Guid id)
  {
    return await _userRepository.GetByIdAsync(id);
  }

  public async Task AddUserAsync(string name)
  {
    var user = new User(name);
    await _userRepository.AddAsync(user);
  }
}
