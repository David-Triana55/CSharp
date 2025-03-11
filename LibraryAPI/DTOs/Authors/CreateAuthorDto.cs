using System.ComponentModel.DataAnnotations;
namespace LibraryAPI.DTOs;


public class CreateAuthorDto
{
  [Required]
  public string Name { get; set; }
  [Required]
  public string Nationality { get; set; }
  [Required]
  public DateOnly Birthdate { get; set; }
}