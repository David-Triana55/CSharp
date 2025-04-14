namespace LibraryAPI.App.Interfaces;
using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Entities.ValueObjects;

public interface ILoanService
{
  Task<IEnumerable<ResponseLoanDto>> GetLoans();
  Task CreateLoan(CreateLoanDto loan);
  Task RegisterReturnLoan(LoanId id);
  Task<ResponseLoanDto> GetLoanId(LoanId id);
  Task DeleteLoan(LoanId id);
}