using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService service) : ControllerBase
{
  readonly IUserService _userService = service;

  [HttpGet]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Get()
  {
    try
    {
      var response = await _userService.GetUsers();
      return Ok(response);
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

  [Route("login")]
  [HttpPost]
  public async Task<IActionResult> Post(LoginUserDto user)
  {
    try
    {
      var token = await _userService.SignIn(user.Email, user.Password);
      return Ok(new { token });
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

  [Route("register")]
  [HttpPost]
  public async Task<IActionResult> Post(RegisterUserDto user)
  {
    try
    {
      await _userService.Register(user);
      return Created();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

  [HttpDelete("{id}")]
  [Authorize(Roles = "admin")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      await _userService.DeleteUser(id);
      return NoContent();
    }
    catch (Exception ex)
    {
      return StatusCode(500, new { message = ex.Message });
    }
  }

}