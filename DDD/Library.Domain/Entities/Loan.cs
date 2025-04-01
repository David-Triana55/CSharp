namespace Library.Domain.Entities;

public class Loan
{
  public Guid Id { get; private set; }
  public Guid UserId { get; private set; }
  public Guid BookId { get; private set; }
  public DateTime BorrowedDate { get; private set; }
  public DateTime? ReturnedDate { get; private set; }

  private Loan() { } // Constructor privado para EF

  public Loan(Guid userId, Guid bookId)
  {
    Id = Guid.NewGuid();
    UserId = userId;
    BookId = bookId;
    BorrowedDate = DateTime.UtcNow;
  }

  public void ReturnBook()
  {
    if (ReturnedDate != null)
      throw new InvalidOperationException("Book already returned.");

    ReturnedDate = DateTime.UtcNow;
  }
}
