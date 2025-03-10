using System.Collections.ObjectModel;
using LibraryAPI.Models;


public class Book
{
  public int Id { get; set; }
  public int AuthorId { get; set; }
  public string Title { get; set; }
  public string Genre { get; set; }
  public DateOnly PublicationDate { get; set; }

  public EBookStatus Status { get; set; }
  public virtual Author? Author { get; set; }
  public virtual ICollection<Loan> Loans { get; set; } = [];


}

public enum EBookStatus
{
  borrowed = 0,
  available = 1
}