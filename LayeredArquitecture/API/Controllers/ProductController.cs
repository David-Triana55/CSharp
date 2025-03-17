using LayeredArquitecture.Application.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private readonly ProductService _service;

  public ProductController(ProductService service)
  {
    _service = service;
  }

  [HttpGet]
  public IActionResult GetProducts()
  {
    return Ok(_service.GetAllProducts());
  }
}
