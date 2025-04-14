namespace LibraryAPI.Infrastructure.DB.Models;

public class UserEntity
{
  public Guid Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }
  public string Password { get; set; }
  public string IdNumber { get; set; }
  public string Role { get; set; }
  public virtual ICollection<LoanEntity> Loans { get; set; } // navigation property
}