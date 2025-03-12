using System.ComponentModel.DataAnnotations;
namespace LibraryAPI.DTOs;
public class CreateLoanDto
{
  [Required]
  public int UserId { get; set; }
  [Required]
  public int BookId { get; set; }

}