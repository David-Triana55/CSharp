
namespace LibraryAPI.App.DTOs;
public class ResponseLoanDto
{
  public Guid Id { get; set; }
  public Guid UserId { get; set; }
  public Guid BookId { get; set; }
  public DateTime LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }

  public ResponseBookDto? Book { get; set; }

  public ResponseUserDto? User { get; set; }

}