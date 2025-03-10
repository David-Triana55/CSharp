using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class CategoriesController : ControllerBase
{
  ICategoryService _categoryService;
  public CategoriesController(ICategoryService service)
  {
    _categoryService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_categoryService.Get());
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody] Category category)
  {
    await _categoryService.Create(category);
    return RedirectToRoute(new { controller = "Categories", action = "get" });
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Category category)
  {
    await _categoryService.Update(id, category);
    return Ok(new { message = "Category update successfully" });
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete([FromRoute] Guid id)
  {
    await _categoryService.Remove(id);
    return Ok(new { message = "Category remove successfully" });
  }
}