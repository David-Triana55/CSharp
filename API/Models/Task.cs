using Microsoft.EntityFrameworkCore;
namespace API.Models;
public class Task
{
  public Guid Id { get; set; }
  public Guid CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }

  public DateTime CreatedAt { get; set; }

  public TaskPriority Priority { get; set; }

  public virtual Category Category { get; set; }
  public bool IsActive { get; set; }

}

public enum TaskPriority
{
  Low = 1,
  Medium = 2,
  High = 3
}