using LibraryAPI.Domain.Entities.ValueObjects;

namespace LibraryAPI.Domain.Entities;
public class Author
{
  public AuthorId Id { get; set; }
  public string Name { get; set; }
  public string Nationality { get; set; }

  public DateOnly Birthdate { get; set; }


  public Author(string name, string nationality, DateOnly birthdate)
  {
    if (string.IsNullOrEmpty(name))
      throw new ArgumentException("Name can't be empty");

    if (string.IsNullOrEmpty(nationality))
      throw new ArgumentException("Nationality can't be empty");

    if (birthdate > DateOnly.FromDateTime(DateTime.UtcNow))
      throw new ArgumentException("Birthdate cannot be in the future");

    Id = new AuthorId(Guid.NewGuid());
    Name = name;
    Nationality = nationality;
    Birthdate = birthdate;
  }

  // Constructor para reconstrucción desde la DB
  public Author(AuthorId id, string name, string nationality, DateOnly birthdate)
  {
    Id = id;
    Name = name;
    Nationality = nationality;
    Birthdate = birthdate;
  }
}