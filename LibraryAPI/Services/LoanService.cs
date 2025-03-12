using System.Collections;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

public class LoanService(LibraryContext context) : ILoanService
{
  readonly LibraryContext _context = context;

  public async Task<IEnumerable<ResponseLoanDto>> GetLoans()
  {
    return await _context.Loans
      .Include(l => l.Book)
      .ThenInclude(b => b.Author)
      .Include(l => l.User)
      .Select(l => new ResponseLoanDto
      {
        Id = l.Id,
        BookId = l.BookId,
        UserId = l.UserId,
        LoanDate = l.LoanDate,
        ReturnDate = l.ReturnDate,
        User = new ResponseUserDto
        {
          Id = l.User.Id,
          Name = l.User.Name,
          Email = l.User.Email,
          IdNumber = l.User.IdNumber,
        },
        Book = new ResponseBookDto
        {
          Id = l.Book.Id,
          Title = l.Book.Title,
          Genre = l.Book.Genre,
          PublicationDate = l.Book.PublicationDate,
          AuthorId = l.Book.Author.Id,
          Status = l.Book.Status,
          Author = new ResponseAuthorDto
          {
            Id = l.Book.Author.Id,
            Name = l.Book.Author.Name,
            Birthdate = l.Book.Author.Birthdate,
            Nationality = l.Book.Author.Nationality
          }
        }
      }).ToListAsync();
  }

  public async Task<ResponseLoanDto> GetLoanId(int id)
  {
    bool existLoan = await _context.Loans.AnyAsync(l => l.Id == id);
    if (!existLoan)
    {
      throw new Exception("Loan doesn't exist");
    }
    return await _context.Loans
      .Where(l => l.Id == id)
      .Include(l => l.Book)
      .ThenInclude(b => b.Author)
      .Include(l => l.User)
      .Select(l => new ResponseLoanDto
      {
        Id = l.Id,
        BookId = l.BookId,
        UserId = l.UserId,
        LoanDate = l.LoanDate,
        ReturnDate = l.ReturnDate,
        User = new ResponseUserDto
        {
          Id = l.User.Id,
          Name = l.User.Name,
          Email = l.User.Email,
          IdNumber = l.User.IdNumber,
        },
        Book = new ResponseBookDto
        {
          Id = l.Book.Id,
          Title = l.Book.Title,
          Genre = l.Book.Genre,
          PublicationDate = l.Book.PublicationDate,
          AuthorId = l.Book.Author.Id,
          Status = l.Book.Status,
          Author = new ResponseAuthorDto
          {
            Id = l.Book.Author.Id,
            Name = l.Book.Author.Name,
            Birthdate = l.Book.Author.Birthdate,
            Nationality = l.Book.Author.Nationality
          }
        }
      }).FirstAsync();
  }

  public async Task CreateLoan(CreateLoanDto loan)
  {
    bool userExist = await _context.Users.AnyAsync(u => u.Id == loan.UserId);
    if (!userExist)
    {
      throw new Exception("User doesn't exist");
    }

    bool isBookBorrowed = await _context.Books.AnyAsync(b => b.Id == loan.BookId && b.Status == EBookStatus.borrowed);
    if (isBookBorrowed)
    {
      throw new Exception("Book already borrowed");
    }

    Book changeStatusBook = await _context.Books.FindAsync(loan.BookId);
    if (changeStatusBook == null)
    {
      throw new Exception("Book doesn't exist");
    }

    changeStatusBook.Status = EBookStatus.borrowed;

    Loan bookToLoan = new Loan
    {
      UserId = loan.UserId,
      BookId = loan.BookId,
      LoanDate = DateTime.UtcNow
    };

    await _context.Loans.AddAsync(bookToLoan);
    await _context.SaveChangesAsync();
  }

  public async Task RegisterReturnLoan(int id)
  {
    Loan loan = await _context.Loans.FindAsync(id);
    if (loan == null)
    {
      throw new Exception("Loan doesn't exist");
    }

    Book changeStatusBook = await _context.Books.FindAsync(loan.BookId);
    if (changeStatusBook == null)
    {
      throw new Exception("Book doesn't exist");
    }

    changeStatusBook.Status = EBookStatus.available;
    loan.ReturnDate = DateTime.UtcNow;
    _context.SaveChanges();
  }

  public async Task DeleteLoan(int id)
  {
    Loan loan = await _context.Loans.FindAsync(id);
    if (loan == null)
    {
      throw new Exception("Loan doesn't exist");
    }

    _context.Loans.Remove(loan);
    await _context.SaveChangesAsync();
  }
}

public interface ILoanService
{
  Task<IEnumerable<ResponseLoanDto>> GetLoans();
  Task CreateLoan(CreateLoanDto loan);
  Task RegisterReturnLoan(int id);
  Task<ResponseLoanDto> GetLoanId(int id);
  Task DeleteLoan(int id);
}