namespace LibraryAPI.Models;

public class User
{
  public int Id { get; set; }
  public string Email { get; set; }
  public string Name { get; set; }
  public string Password { get; set; }
  public string IdNumber { get; set; }
  public string Role { get; set; }
  public virtual ICollection<Loan> Loans { get; set; } // navigation property
}