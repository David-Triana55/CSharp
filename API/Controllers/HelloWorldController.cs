using Microsoft.AspNetCore.Mvc;
using API.Services;
namespace API.Controllers;


[ApiController]
[Route("/api/[controller]")]

public class HelloWorldController : ControllerBase
{
  private readonly IHelloWorldService _helloWorldService;
  private readonly ILogger<HelloWorldController> _logger;

  public HelloWorldController(IHelloWorldService helloWorldService, ILogger<HelloWorldController> logger)
  {
    _helloWorldService = helloWorldService;
    _logger = logger;
  }

  [HttpGet]
  public IActionResult Get()
  {
    _logger.LogInformation("Hello World");
    return Ok(_helloWorldService.GetHelloWorld());
  }
}