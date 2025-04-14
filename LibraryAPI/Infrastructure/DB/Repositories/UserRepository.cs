namespace LibraryAPI.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Domain.Common;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Exceptions;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure.DB.Data;
using LibraryAPI.Infrastructure.DB.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepository(LibraryContext context) : IUserRepository
{
  private readonly LibraryContext _context = context;

  public async Task<IEnumerable<User>> GetUsers()
  {
    var userEntityList = await _context.Users.ToListAsync();

    return userEntityList.Select(u =>
    {
      var user = new User(
        new UserId(u.Id),
        u.Email,
        u.Name,
        u.Password,
        u.IdNumber,
        u.Role
      );

      return user;
    }).ToList();
  }

  public Task Register(User user)
  {

    bool alreadyRegister = _context.Users.Any(u => u.Email == user.Email);

    if (alreadyRegister)
    {
      throw new Exception(ErrorMessages.UserAlreadyExists);
    }

    var userAdd = new UserEntity
    {
      Id = user.Id.Value,
      Email = user.Email,
      Name = user.Name,
      Password = user.Password,
      IdNumber = user.IdNumber,
      Role = user.Role
    };

    _context.Users.Add(userAdd);
    return _context.SaveChangesAsync();
  }

  public async Task<User> GetByEmail(string email)
  {
    var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ?? throw new UserNotFoundException();

    var user = new User(
      new UserId(userEntity.Id),
      userEntity.Email,
      userEntity.Name,
      userEntity.Password,
      userEntity.IdNumber,
      userEntity.Role
    );

    return user;
  }

  public async Task DeleteUser(UserId id)
  {
    var editUser = await _context.Users.FindAsync(id.Value) ?? throw new UserNotFoundException();

    _context.Users.Remove(editUser);
    await _context.SaveChangesAsync();
  }

  public bool UserExist(string email)
  {
    return _context.Users.Any(u => u.Email == email);
  }

}