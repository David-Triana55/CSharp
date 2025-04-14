namespace LibraryAPI.App.Services;

using System.Collections.Generic;
using LibraryAPI.App.DTOs;
using LibraryAPI.App.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

public class LoanService(ILoanRepository repository) : ILoanService
{
  private readonly ILoanRepository _repository = repository;

  public async Task<IEnumerable<ResponseLoanDto>> GetLoans()
  {
    var loans = await _repository.GetLoans();

    return loans.Select(l => new ResponseLoanDto
    {
      Id = l.Id.Value,
      BookId = l.BookId.Value,
      UserId = l.UserId.Value,
      LoanDate = l.LoanDate,
      ReturnDate = l.ReturnDate,
      User = new ResponseUserDto
      {
        Id = l.User.Id.Value,
        Name = l.User.Name,
        Email = l.User.Email,
        IdNumber = l.User.IdNumber,
      },
      Book = new ResponseBookDto
      {
        Id = l.Book.Id.Value,
        Title = l.Book.Title,
        Genre = l.Book.Genre,
        PublicationDate = l.Book.PublicationDate,
        AuthorId = l.Book.AuthorId,
        Status = l.Book.Status,
        Author = new ResponseAuthorDto
        {
          Id = l.Author.Id.Value,
          Name = l.Author.Name,
          Birthdate = l.Author.Birthdate,
          Nationality = l.Author.Nationality
        }
      }
    }).ToList();

  }

  public async Task<ResponseLoanDto> GetLoanId(LoanId id)
  {
    var loan = await _repository.GetLoanId(id);

    return new ResponseLoanDto
    {
      Id = loan.Id.Value,
      BookId = loan.BookId.Value,
      UserId = loan.UserId.Value,
      LoanDate = loan.LoanDate,
      ReturnDate = loan.ReturnDate,
      User = new ResponseUserDto
      {
        Id = loan.User.Id.Value,
        Name = loan.User.Name,
        Email = loan.User.Email,
        IdNumber = loan.User.IdNumber,
      },
      Book = new ResponseBookDto
      {
        Id = loan.Book.Id.Value,
        Title = loan.Book.Title,
        Genre = loan.Book.Genre,
        PublicationDate = loan.Book.PublicationDate,
        AuthorId = loan.Book.AuthorId,
        Status = loan.Book.Status,
        Author = new ResponseAuthorDto
        {
          Id = loan.Author.Id.Value,
          Name = loan.Author.Name,
          Birthdate = loan.Author.Birthdate,
          Nationality = loan.Author.Nationality
        }
      }
    };

  }

  public async Task CreateLoan(CreateLoanDto loan)
  {
    await _repository.CreateLoan(new BookId(loan.BookId), new UserId(loan.UserId));
  }

  public async Task RegisterReturnLoan(LoanId id)
  {
    await _repository.RegisterReturnLoan(id);
  }

  public async Task DeleteLoan(LoanId id)
  {
    _repository.DeleteLoan(id);
  }
}

