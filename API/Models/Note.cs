using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace API.Models;
public class Note
{
  public Guid Id { get; set; }
  public Guid CategoryId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }

  public DateTime CreatedAt { get; set; }

  public NotePriority Priority { get; set; }
  [JsonIgnore]
  public virtual Category Category { get; set; }
  public bool IsActive { get; set; }

}

public enum NotePriority
{
  Low = 1,
  Medium = 2,
  High = 3
}