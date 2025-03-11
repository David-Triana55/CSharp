using System.Collections;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

public class LoanService : ILoanService
{
  readonly LibraryContext _context;

  public LoanService(LibraryContext context)
  {
    _context = context;
  }

  // mostrar historial de prestamos

  public IEnumerable<Loan> GetLoans()
  {
    return _context.Loans;
  }

  // crear un prestamo

  public void CreateLoan(CreateLoanDto loan)
  {
    // buscar si el id del libro ya ha sido prestado 
    // si es asi, lanzar excepcion
    // si no es asi, guardar el prestamo
    Book loanBook = _context.Books.Where(b => b.Id == loan.BookId && b.Status == EBookStatus.borrowed).First();

    if (loanBook != null)
    {
      throw new Exception("El libro ya ha sido prestado");
    }

  }


  // registrar fecha de devolucion

  public void ReturnLoan(int id)
  {
    // buscar el prestamo
    Loan loan = _context.Loans.Where(l => l.Id == id).First();

    if (loan != null)
    {
      loan.ReturnDate = DateTime.Now;
      _context.SaveChanges();
    }
  }


}

public interface ILoanService
{
  IEnumerable<Loan> GetLoans();
  void CreateLoan(CreateLoanDto loan);
}