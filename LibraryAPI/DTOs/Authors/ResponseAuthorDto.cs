namespace LibraryAPI.DTOs;
public class ResponseAuthorDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Nationality { get; set; }

  public DateOnly Birthdate { get; set; }

}