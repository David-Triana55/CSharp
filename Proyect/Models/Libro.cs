
public class Libro
{
  public string Titulo { get; set; }
  public string Autor { get; set; }
  public string Genero { get; set; }
  public DateTime FechaPublicacion { get; set; }
  public string Estado { get; set; } = "Disponible";


  public Libro(string titulo, string autor, string genero, DateTime fechaPublicacion)
  {
    Titulo = titulo;
    Autor = autor;
    Genero = genero;
    FechaPublicacion = fechaPublicacion;
  }
}