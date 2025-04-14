using System.ComponentModel.DataAnnotations;
using LibraryAPI.Domain.Enums;
namespace LibraryAPI.App.DTOs;


public class UpdateBookDto
{
  [Required]
  public Guid AuthorId { get; set; }
  [Required, MinLength(3)]
  public string Title { get; set; }
  [Required, MinLength(5)]
  public string Genre { get; set; }
  [Required]
  public DateOnly PublicationDate { get; set; }
  [Range(0, 1)]
  public EBookStatus Status { get; set; }
}