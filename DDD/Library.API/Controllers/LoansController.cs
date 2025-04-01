using Library.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
  private readonly LoanService _loanService;

  public LoansController(LoanService loanService)
  {
    _loanService = loanService;
  }

  [HttpPost("borrow")]
  public async Task<IActionResult> BorrowBook(Guid userId, Guid bookId)
  {
    await _loanService.BorrowBookAsync(userId, bookId);
    return Ok();
  }

  [HttpPost("return")]
  public async Task<IActionResult> ReturnBook(Guid loanId)
  {
    await _loanService.ReturnBookAsync(loanId);
    return Ok();
  }

  [HttpGet("active/{userId}")]
  public async Task<IActionResult> GetActiveLoans(Guid userId)
  {
    var loans = await _loanService.GetUserActiveLoansAsync(userId);
    return Ok(loans);
  }
}
