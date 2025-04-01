namespace Library.Application.Services;
using Library.Domain.Entities;
using Library.Domain.Repositories;

public class LoanService
{
  private readonly ILoanRepository _loanRepository;
  private readonly IBookRepository _bookRepository;

  public LoanService(ILoanRepository loanRepository, IBookRepository bookRepository)
  {
    _loanRepository = loanRepository;
    _bookRepository = bookRepository;
  }

  public async Task BorrowBookAsync(Guid userId, Guid bookId)
  {
    var book = await _bookRepository.GetByIdAsync(bookId);
    if (book == null) throw new InvalidOperationException("Book not found.");

    book.Borrow();
    await _bookRepository.UpdateAsync(book);

    var loan = new Loan(userId, bookId);
    await _loanRepository.AddAsync(loan);
  }

  public async Task ReturnBookAsync(Guid loanId)
  {
    var loan = await _loanRepository.GetByIdAsync(loanId);
    if (loan == null) throw new InvalidOperationException("Loan not found.");

    loan.ReturnBook();
    await _loanRepository.UpdateAsync(loan);

    var book = await _bookRepository.GetByIdAsync(loan.BookId);
    book?.Return();
    if (book != null) await _bookRepository.UpdateAsync(book);
  }

  public async Task<IEnumerable<Loan>> GetUserActiveLoansAsync(Guid userId)
  {
    return await _loanRepository.GetActiveLoansByUserIdAsync(userId);
  }
}
