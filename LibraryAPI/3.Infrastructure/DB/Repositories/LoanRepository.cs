namespace LibraryAPI.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Domain.Common;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Enums;
using LibraryAPI.Domain.Exceptions;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure.DB.Data;
using LibraryAPI.Infrastructure.DB.Models;
using Microsoft.EntityFrameworkCore;

public class LoanRepository(LibraryContext context) : ILoanRepository
{
  private readonly LibraryContext _context = context;

  public async Task<IEnumerable<Loan>> GetLoans()
  {
    var loanEntityList = await _context.Loans
      .Include(l => l.Book)
      .ThenInclude(b => b.Author)
      .Include(l => l.User)
      .ToListAsync();

    var loans = loanEntityList.Select(l =>
    {
      var loan = new Loan(
        new LoanId(l.Id),
        new UserId(l.UserId),
        new BookId(l.BookId),
        l.LoanDate,
        l.ReturnDate
      );

      var user = new User(
        new UserId(l.User.Id),
        l.User.Email,
        l.User.Name,
        l.User.Password,
        l.User.IdNumber,
        l.User.Role
      );

      var author = new Author(
        new AuthorId(l.Book.Author.Id),
        l.Book.Author.Name,
        l.Book.Author.Nationality,
        l.Book.Author.Birthdate
      );

      var book = new Book(
        new BookId(l.Book.Id),
        new AuthorId(l.Book.AuthorId),
        l.Book.Title,
        l.Book.Genre,
        l.Book.PublicationDate,
        l.Book.Status
      );

      loan.Book = book;
      loan.User = user;
      loan.Author = author;

      return loan;
    }).ToList();

    return loans;

  }

  public async Task<Loan> GetLoanId(LoanId id)
  {
    bool existLoan = await _context.Loans.AnyAsync(l => l.Id == id.Value);

    if (!existLoan)
    {
      throw new LoanNotFoundException();
    }

    var loanEntity = await _context.Loans.Include(l => l.Book)
      .ThenInclude(b => b.Author)
      .Include(l => l.User)
      .FirstOrDefaultAsync(l => l.Id == id.Value);

    var loan = new Loan(
      new LoanId(loanEntity.Id),
      new UserId(loanEntity.UserId),
      new BookId(loanEntity.BookId),
      loanEntity.LoanDate,
      loanEntity.ReturnDate
    );

    var user = new User(
      new UserId(loanEntity.User.Id),
      loanEntity.User.Email,
      loanEntity.User.Name,
      loanEntity.User.Password,
      loanEntity.User.IdNumber,
      loanEntity.User.Role
    );

    var author = new Author(
      new AuthorId(loanEntity.Book.Author.Id),
      loanEntity.Book.Author.Name,
      loanEntity.Book.Author.Nationality,
      loanEntity.Book.Author.Birthdate
    );

    var book = new Book(
      new BookId(loanEntity.Book.Id),
      new AuthorId(loanEntity.Book.AuthorId),
      loanEntity.Book.Title,
      loanEntity.Book.Genre,
      loanEntity.Book.PublicationDate,
      loanEntity.Book.Status
    );

    loan.Book = book;
    loan.User = user;
    loan.Author = author;


    return loan;
  }

  public async Task CreateLoan(BookId bookId, UserId userId)
  {
    var userExist = await _context.Users.FindAsync(userId.Value) ?? throw new UserNotFoundException();

    bool isBookBorrowed = await _context.Books.AnyAsync(b => b.Id == bookId.Value && b.Status == EBookStatus.borrowed);

    if (isBookBorrowed)
    {
      throw new BookIsBorrowedException();
    }

    var changeStatusBook = await _context.Books.FindAsync(bookId.Value) ?? throw new BookNotFoundException();

    changeStatusBook.Status = EBookStatus.borrowed;

    var loanEntity = new LoanEntity
    {
      Id = Guid.NewGuid(),
      UserId = userId.Value,
      BookId = bookId.Value,
      LoanDate = DateTime.UtcNow
    };

    await _context.Loans.AddAsync(loanEntity);
    await _context.SaveChangesAsync();
  }

  public async Task RegisterReturnLoan(LoanId id)
  {
    LoanEntity loan = await _context.Loans.FindAsync(id.Value) ?? throw new LoanNotFoundException();

    BookEntity changeStatusBook = await _context.Books.FindAsync(loan.BookId) ?? throw new BookNotFoundException();

    changeStatusBook.Status = EBookStatus.available;
    loan.ReturnDate = DateTime.UtcNow;

    _context.SaveChanges();
  }

  public async Task DeleteLoan(LoanId id)
  {
    LoanEntity loan = await _context.Loans.FindAsync(id.Value) ?? throw new LoanNotFoundException();

    _context.Loans.Remove(loan);
    await _context.SaveChangesAsync();
  }
}