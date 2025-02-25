public class Autor
{
  public string Nombre { get; set; }
  public DateTime FechaNacimiento { get; set; }
  public string Nacionalidad { get; set; }
  public List<string> Libros { get; set; }

  public Autor(string nombre, string nacionalidad, DateTime fechaNacimiento, List<string> libros)
  {
    Nombre = nombre;
    Nacionalidad = nacionalidad;
    FechaNacimiento = fechaNacimiento;
    Libros = libros;
  }
}