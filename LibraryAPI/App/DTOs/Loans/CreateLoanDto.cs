using System.ComponentModel.DataAnnotations;
namespace LibraryAPI.App.DTOs;
public class CreateLoanDto
{
  [Required]
  public Guid UserId { get; set; }
  [Required]
  public Guid BookId { get; set; }


}