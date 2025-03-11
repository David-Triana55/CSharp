using System.ComponentModel.DataAnnotations;
namespace LibraryAPI.DTOs;


public class CreateBookDto
{
  [Required]
  public int AuthorId { get; set; }
  [Required, MinLength(3)]
  public string Title { get; set; }
  [Required, MinLength(5)]
  public string Genre { get; set; }
  [Required]
  public DateOnly PublicationDate { get; set; }
  [Range(0, 1)]
  public EBookStatus Status { get; set; }
}