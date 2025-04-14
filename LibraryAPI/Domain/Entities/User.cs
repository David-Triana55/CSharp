using LibraryAPI.Domain.Entities.ValueObjects;

namespace LibraryAPI.Domain.Entities;

public class User
{
  public UserId Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }
  public string Password { get; set; }
  public string IdNumber { get; set; }
  public string Role { get; set; }


  public User(string email, string name, string password, string idNumber, string role)
  {
    if (string.IsNullOrEmpty(email))
      throw new ArgumentException("Email can't be empty");
    if (string.IsNullOrEmpty(name))
      throw new ArgumentException("Name can't be empty");
    if (string.IsNullOrEmpty(password))
      throw new ArgumentException("Password can't be empty");
    if (string.IsNullOrEmpty(idNumber))
      throw new ArgumentException("IdNumber can't be empty");
    if (string.IsNullOrEmpty(role))
      throw new ArgumentException("Role can't be empty");
    Id = new UserId(Guid.NewGuid());
    Email = email;
    Name = name;
    Password = password;
    IdNumber = idNumber;
    Role = role;
  }

  public User(UserId id, string email, string name, string password, string idNumber, string role)
  {
    Id = id;
    Email = email;
    Name = name;
    Password = password;
    IdNumber = idNumber;
    Role = role;
  }
}