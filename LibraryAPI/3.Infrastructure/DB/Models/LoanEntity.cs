namespace LibraryAPI.Infrastructure.DB.Models;
public class LoanEntity
{
  public Guid Id { get; set; }
  public Guid UserId { get; set; }
  public Guid BookId { get; set; }
  public DateTime LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }
  public virtual UserEntity User { get; set; } // navigation property
  public virtual BookEntity Book { get; set; } // navigation property
}