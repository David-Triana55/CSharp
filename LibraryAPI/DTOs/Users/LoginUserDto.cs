using System.ComponentModel.DataAnnotations;
namespace LibraryAPI.DTOs;

public class LoginUserDto
{
  [EmailAddress]
  public string Email { get; set; }
  [Required]
  public string Password { get; set; }

}