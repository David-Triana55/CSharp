namespace API.Services;

using System.Runtime.CompilerServices;
using API.Models;
using Microsoft.EntityFrameworkCore;

// contiene toda la logica y se encargan de realizar las operaciones de la base de datos
public class CategoryService : ICategoryService
{
  NotesContext _context;

  public CategoryService(NotesContext Dbcontext)
  {
    _context = Dbcontext;
  }

  public IEnumerable<Category> Get()
  {
    return _context.Categories.Include(p => p.Notes).ToList();
  }

  public async Task Create(Category category)
  {
    await _context.AddAsync(category);
    await _context.SaveChangesAsync();
  }
  public async Task Update(Guid id, Category category)
  {
    Category existCategory = await _context.Categories.FindAsync(id);

    if (existCategory != null)
    {
      existCategory.Name = category.Name;
      existCategory.Description = category.Description;

      await _context.SaveChangesAsync();
    }
  }

  public async Task Remove(Guid id)
  {
    Category existCategory = await _context.Categories.FindAsync(id);

    if (existCategory != null)
    {
      _context.Remove(existCategory);
      await _context.SaveChangesAsync();
    }
  }

}
public interface ICategoryService
{
  IEnumerable<Category> Get();
  Task Create(Category category);
  Task Update(Guid id, Category category);

  Task Remove(Guid id);
}


