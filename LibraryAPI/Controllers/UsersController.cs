using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
  IUserService _userService;
  public UsersController(IUserService service)
  {
    _userService = service;
  }

  [Route("login")]
  [HttpPost]
  public async Task<IActionResult> Login(LoginUserDto user)
  {
    var token = await _userService.Login(user.Email, user.Password);
    return Ok(new { token });
  }

  [Route("register")]
  [HttpPost]
  public async Task<IActionResult> Register(RegisterUserDto user)
  {
    await _userService.Register(user);
    return Created();
  }




}