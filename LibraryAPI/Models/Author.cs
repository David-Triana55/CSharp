using System.Text.Json.Serialization;

namespace LibraryAPI.Models;
public class Author
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Nationality { get; set; }

  public DateOnly Birthdate { get; set; }

  public virtual ICollection<Book> Books { get; set; } = [];
}