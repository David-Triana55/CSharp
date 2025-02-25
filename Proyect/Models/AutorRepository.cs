using System.Text.Json;
public class AutorRepository : IAutorRepository
{
  public List<Autor> Autores { get; set; } = [];

  public AutorRepository()
  {
    using StreamReader reader = new("./utils/autores.json");
    string json = reader.ReadToEnd();
    Autores = JsonSerializer.Deserialize<List<Autor>>(json);
  }

  public void AgregarAutor(Autor autor)
  {
    Autores.Add(autor);
  }

  public void EditarAutor(int indice, Autor autor)
  {
    if (indice >= 0 && indice < Autores.Count)
    {
      Autores[indice] = autor;
    }
  }

  public void EliminarAutor(int indice)
  {
    Autores.RemoveAt(indice);
  }

  public List<Autor> ObtenerAutores()
  {
    return Autores;
  }

  public bool VerificarExistencia(string nombre)
  {
    return Autores.Exists(p => p.Nombre == nombre);
  }
}


