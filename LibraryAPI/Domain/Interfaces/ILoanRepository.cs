namespace LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;

public interface ILoanRepository
{
  Task<IEnumerable<Loan>> GetLoans();
  Task CreateLoan(BookId bookId, UserId userId);
  Task RegisterReturnLoan(LoanId id);
  Task<Loan> GetLoanId(LoanId id);
  Task DeleteLoan(LoanId id);
}