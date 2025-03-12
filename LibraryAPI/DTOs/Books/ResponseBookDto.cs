
namespace LibraryAPI.DTOs;
public class ResponseBookDto
{
  public int Id { get; set; }
  public int AuthorId { get; set; }
  public string Title { get; set; }
  public string Genre { get; set; }
  public DateOnly PublicationDate { get; set; }
  public EBookStatus Status { get; set; }
  public ResponseAuthorDto? Author { get; set; }

}