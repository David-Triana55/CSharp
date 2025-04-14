namespace LibraryAPI.App.Interfaces;
using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Entities.ValueObjects;
public interface IUserService
{
  Task<IEnumerable<ResponseUserDto>> GetUsers();
  Task Register(RegisterUserDto user);
  Task<string> SignIn(string email, string password);
  Task DeleteUser(UserId id);
}