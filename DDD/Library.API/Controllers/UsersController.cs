using Library.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
  private readonly UserService _userService;

  public UsersController(UserService userService)
  {
    _userService = userService;
  }

  [HttpPost]
  public async Task<IActionResult> AddUser([FromBody] CreateUserDto createUserDto)
  {
    await _userService.AddUserAsync(createUserDto.Name);
    return Ok();
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetUserById(Guid id)
  {
    var user = await _userService.GetUserByIdAsync(id);
    if (user == null) return NotFound();

    return Ok(user);
  }
}
