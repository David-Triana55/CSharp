namespace LibraryAPI.Models;
public class Loan
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public int BookId { get; set; }
  public DateOnly LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }

  public virtual User User { get; set; }
  public virtual Book Book { get; set; }
}