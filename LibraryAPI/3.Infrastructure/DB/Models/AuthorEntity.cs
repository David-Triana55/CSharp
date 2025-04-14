namespace LibraryAPI.Infrastructure.DB.Models;
using System.Text.Json.Serialization;

public class AuthorEntity
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Nationality { get; set; }

  public DateOnly Birthdate { get; set; }

  public virtual ICollection<BookEntity> Books { get; set; } // navigation property
}

