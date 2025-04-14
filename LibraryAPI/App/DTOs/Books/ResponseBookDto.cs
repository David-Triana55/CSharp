
using LibraryAPI.Domain.Enums;

namespace LibraryAPI.App.DTOs;
public class ResponseBookDto
{
  public Guid Id { get; set; }
  public Guid AuthorId { get; set; }
  public string Title { get; set; }
  public string Genre { get; set; }
  public DateOnly PublicationDate { get; set; }
  public EBookStatus Status { get; set; }
  public ResponseAuthorDto? Author { get; set; }

}