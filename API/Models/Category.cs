using Microsoft.EntityFrameworkCore;
namespace API.Models;

public class Category
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public virtual ICollection<Note> Notes { get; set; }
}