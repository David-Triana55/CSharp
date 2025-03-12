using System.Buffers;
using LibraryAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
namespace LibraryAPI.Controllers;

[Authorize(Roles = "admin")]
[ApiController]
[Route("api/[controller]")]
public class LoansController(ILoanService service) : ControllerBase
{
  readonly ILoanService _loanService = service;

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await _loanService.GetLoans();
      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    try
    {
      var response = await _loanService.GetLoanId(id);
      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpPost]
  public async Task<IActionResult> Post(CreateLoanDto loan)
  {
    try
    {
      await _loanService.CreateLoan(loan);
      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id)
  {
    try
    {
      await _loanService.RegisterReturnLoan(id);
      return Ok();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }


  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      await _loanService.DeleteLoan(id);
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

}