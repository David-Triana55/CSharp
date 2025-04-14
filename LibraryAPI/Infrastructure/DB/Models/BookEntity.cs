using System.Collections.ObjectModel;
using LibraryAPI.Domain.Enums;
namespace LibraryAPI.Infrastructure.DB.Models;


public class BookEntity
{
  public Guid Id { get; set; }
  public Guid AuthorId { get; set; }
  public string Title { get; set; }
  public string Genre { get; set; }
  public DateOnly PublicationDate { get; set; }
  public EBookStatus Status { get; set; }
  public virtual AuthorEntity Author { get; set; } // navigation property
  public virtual ICollection<LoanEntity> Loans { get; set; } // navigation property
}
