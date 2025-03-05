using System.Text.Json.Serialization;

namespace EntityFramework.Models;
public class Tarea
{
  // Data notion => [key, required, max length, foreign key, not mapped]
  public Guid TareaId { get; set; }
  public Guid CategoriaId { get; set; }
  public string Titulo { get; set; }
  public string Descripcion { get; set; }
  public Prioridad PrioridadTarea { get; set; }
  public DateTime FechaCreacion { get; set; }
  [JsonIgnore]
  public virtual Categoria Categoria { get; set; }
  public bool IsActive { get; set; }
  public string Resumen { get; set; }
}
public enum Prioridad { Baja = 1, Media = 2, Alta = 3 }

