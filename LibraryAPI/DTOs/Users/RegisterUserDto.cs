namespace LibraryAPI.DTOs;
using System.ComponentModel.DataAnnotations;

public class RegisterUserDto
{
  [Required, EmailAddress]
  public string Email { get; set; }
  [Required]
  public string Name { get; set; }
  [Required, MinLength(6)]
  public string Password { get; set; }
  [Required]
  public string IdNumber { get; set; }
  public string Role { get; set; } = "user";
}