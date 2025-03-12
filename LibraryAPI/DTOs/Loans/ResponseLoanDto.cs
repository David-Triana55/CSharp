
namespace LibraryAPI.DTOs;
public class ResponseLoanDto
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public int BookId { get; set; }
  public DateTime LoanDate { get; set; }
  public DateTime? ReturnDate { get; set; }

  public ResponseBookDto? Book { get; set; }

  public ResponseUserDto? User { get; set; }

}