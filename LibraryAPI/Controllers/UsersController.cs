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
  [HttpPost()]
  public async Task Post(User user)
  {
    Ok(await _userService.Login(user.Email, user.Password));
  }

  [Route("register")]
  [HttpPost()]
  public async Task<IActionResult> Register(User user)
  {
    await _userService.Register(user);
    return Created();
  }




}