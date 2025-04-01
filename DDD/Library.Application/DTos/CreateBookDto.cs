namespace Library.API.Dtos;

public class CreateBookDto
{
  public string Title { get; set; }
  public string Author { get; set; }
  public int AvailableCopies { get; set; }
}
