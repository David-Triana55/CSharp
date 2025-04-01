namespace Library.Domain.Repositories;
using Library.Domain.Entities;

public interface ILoanRepository
{
  Task<Loan?> GetByIdAsync(Guid id);
  Task<IEnumerable<Loan>> GetActiveLoansByUserIdAsync(Guid userId);
  Task AddAsync(Loan loan);
  Task UpdateAsync(Loan loan);
}
s