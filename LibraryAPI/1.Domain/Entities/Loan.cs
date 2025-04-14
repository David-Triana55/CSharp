namespace LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;


public class Loan
{
  public LoanId Id { get; private set; }
  public UserId UserId { get; private set; }
  public BookId BookId { get; private set; }
  public DateTime LoanDate { get; private set; }
  public DateTime? ReturnDate { get; private set; }

  public User? User { get; set; }
  public Book? Book { get; set; }

  public Author? Author { get; set; }

  public Loan(UserId userId, BookId bookId, DateTime loanDate, DateTime? returnDate)
  {

    if (loanDate.Date > DateTime.UtcNow.Date)
      throw new ArgumentException("LoanDate cannot be in the future", nameof(loanDate));

    if (returnDate.HasValue && returnDate.Value.Date < loanDate.Date)
      throw new ArgumentException("ReturnDate cannot be before LoanDate", nameof(returnDate));

    // Asignación de propiedades
    Id = new LoanId(Guid.NewGuid());
    UserId = userId;
    BookId = bookId;
    LoanDate = loanDate;
    ReturnDate = returnDate;
  }

  public Loan(LoanId id, UserId userId, BookId bookId, DateTime loanDate, DateTime? returnDate)
  {
    Id = id;
    UserId = userId;
    BookId = bookId;
    LoanDate = loanDate;
    ReturnDate = returnDate;
  }


  // Método para registrar devolución del libro (ejemplo de comportamiento)
  public void ReturnBook(DateTime returnDate)
  {
    if (returnDate.Date < LoanDate.Date)
      throw new InvalidOperationException("Return date cannot be before loan date.");

    ReturnDate = returnDate;
  }
}

