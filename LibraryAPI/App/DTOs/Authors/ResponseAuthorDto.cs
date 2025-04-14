namespace LibraryAPI.App.DTOs;
public class ResponseAuthorDto
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Nationality { get; set; }

  public DateOnly Birthdate { get; set; }

}