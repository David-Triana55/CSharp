using System.Net.Http.Headers;
using System.Text.Json;

public class LinqQueries
{
  private List<Book> LibrosCollection;
  public LinqQueries()
  {
    using StreamReader reader = new("./books.json");
    string json = reader.ReadToEnd();
    LibrosCollection = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
  }

  public IEnumerable<Book> ObtenerLibrosConLibroDeLibros()
  {
    return LibrosCollection;
  }

  public IEnumerable<Book> ObtenerLibrosDel2000()
  {
    // Extension method
    // return LibrosCollection.Where(l => l.PublishedDate.Year > 2000);
    // Query expresion 
    return from l in LibrosCollection where l.PublishedDate.Year > 2000 select l;
  }

  public IEnumerable<Book> ObtenerLibrosCon250PaginasAccion()
  {
    return LibrosCollection.Where(l => l.PageCount > 250 && l.Title.Contains("Action"));
  }


  public int ObtenerLibrosEntre200Y500Paginas()
  {
    return LibrosCollection.Count(l => l.PageCount >= 200 && l.PageCount <= 500);
  }

  public DateTime ObtnerFechaDePublicacionMasAntigua()
  {
    return LibrosCollection.Min(l => l.PublishedDate);
  }


  public int ObtenerLibroConMayorCantidadDePaginas()
  {
    return LibrosCollection.Max(l => l.PageCount);
  }


  public Book ObtenerLibrosConLaMenorCantidadDePaginas()
  {
    return LibrosCollection.Where(l => l.PageCount > 0).MinBy(l => l.PageCount);
  }

  public IEnumerable<IGrouping<int, Book>> ObtenerLibrosAgrupadosPorYear()
  {
    return LibrosCollection.Where(l => l.PublishedDate.Year > 2000).GroupBy(l => l.PublishedDate.Year);
  }
}
