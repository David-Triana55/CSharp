using System.Text.Json;

public class LibroRepository : ILibroRepository
{
  public List<Libro> Libros { get; set; } = [];

  public LibroRepository()
  {
    using StreamReader reader = new("./utils/libros.json");
    string json = reader.ReadToEnd();
    Libros = JsonSerializer.Deserialize<List<Libro>>(json);
  }
  public void AgregarLibro(Libro libro)
  {
    Libros.Add(libro);
  }

  public void EditarLibro(int indice, Libro libro)
  {
    if (indice >= 0 && indice < Libros.Count)
    {
      Libros[indice] = libro;
    }
    else
    {
      Console.WriteLine("indice inválido");
    }
  }

  public void EliminarLibro(int indice)
  {
    Libros.RemoveAt(indice);
  }

  public List<Libro> ObtenerLibros()
  {
    return Libros;
  }

  public bool VerificarExistencia(string titulo)
  {
    return Libros.Exists(p => p.Titulo == titulo);
  }

  public void EstadoPrestado(string titulo)
  {
    Libros.Find(p => p.Titulo == titulo).Estado = "Prestado";
  }

  public void EstadoDisponible(string titulo)
  {
    Libros.Find(p => p.Titulo == titulo).Estado = "Disponible";
  }
}

