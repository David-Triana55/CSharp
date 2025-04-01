namespace Library.Infrastructure.Repositories;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

public class LoanRepository : ILoanRepository
{
  private readonly LibraryDbContext _context;

  public LoanRepository(LibraryDbContext context)
  {
    _context = context;
  }

  public async Task<Loan?> GetByIdAsync(Guid id)
  {
    return await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
  }

  public async Task<IEnumerable<Loan>> GetActiveLoansByUserIdAsync(Guid userId)
  {
    return await _context.Loans.Where(l => l.UserId == userId && l.ReturnedDate == null).ToListAsync();
  }

  public async Task AddAsync(Loan loan)
  {
    await _context.Loans.AddAsync(loan);
    await _context.SaveChangesAsync();
  }

  public async Task UpdateAsync(Loan loan)
  {
    _context.Loans.Update(loan);
    await _context.SaveChangesAsync();
  }
}
