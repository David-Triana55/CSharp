using System.Buffers;
using LibraryAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
namespace LibraryAPI.Controllers;

[Authorize(Roles = "admin")]
[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
  ILoanService _loanService;
  public LoansController(ILoanService service)
  {
    _loanService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    // mostrar el historial de prestamos
    return Ok(_loanService.GetLoans());

  }

  [HttpPost]
  public IActionResult Post(CreateLoanDto loan)
  {
    _loanService.CreateLoan(loan);
    return Ok();
  }

}