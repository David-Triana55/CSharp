using System.Text.Json.Serialization;

namespace EntityFramework.Models;
public class Categoria
{
  // Data notion => [key, required, max length]
  public Guid CategoriaId { get; set; }
  public string Nombre { get; set; }
  public string Descripcion { get; set; }
  public string Resumen { get; set; }
  public virtual ICollection<Tarea> Tareas { get; set; }
}
