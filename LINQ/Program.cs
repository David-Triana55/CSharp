
LinqQueries queries = new();

// Libros con 250 paginas y titulo que contiene Action
// ImprimirValores(queries.ObtenerLibrosCon250PaginasAccion());

// libros despues del 2000
// ImprimirValores(queries.ObtenerLibrosDel2000());


// Toda la coleccion
// ImprimirValores(queries.ObtenerLibrosConLibroDeLibros());

// Libros entre 200 y 500 paginas
// Console.WriteLine($"Número de libros entre 200 y 500 paginas: {queries.ObtenerLibrosEntre200Y500Paginas()}");

// Fecha de publicación más antigua
// Console.WriteLine($"Fecha de publicación más antigua: {queries.ObtnerFechaDePublicacionMasAntigua().ToShortDateString()}");

// libro con mayor cantidad de paginas
// Console.WriteLine($"Libro con mayor cantidad de paginas: {queries.ObtenerLibroConMayorCantidadDePaginas()}");


// Libro con menor cantidad de paginas
// Console.WriteLine($"Libro con menor cantidad de paginas: {queries.ObtenerLibrosConLaMenorCantidadDePaginas().Title}  con {queries.ObtenerLibrosConLaMenorCantidadDePaginas().PageCount} paginas");

// Libros agrupados por año

foreach (IGrouping<int, Book> agrupacion in queries.ObtenerLibrosAgrupadosPorYear())
{
  Console.WriteLine($"Año: {agrupacion.Key}");
  foreach (Book libro in agrupacion)
  {
    Console.WriteLine($"  Título: {libro.Title}");
    Console.WriteLine($"  Cantidad de páginas: {libro.PageCount}");
    Console.WriteLine($"  Fecha de publicación: {libro.PublishedDate.ToShortDateString()}");
    Console.WriteLine($"  URL de la miniatura: {libro.ThumbnailUrl}");
    Console.WriteLine($"  Estado: {libro.Status}");
    Console.WriteLine($"  Autores: {string.Join(", ", libro.Authors)}");
    Console.WriteLine($"  Categorías: {string.Join(", ", libro.Categories)}");
    Console.WriteLine();
  }
}

void ImprimirValores(IEnumerable<Book> libros)
{
  foreach (Book libro in libros)
  {
    Console.WriteLine($"Título: {libro.Title}");
    Console.WriteLine($"Cantidad de páginas: {libro.PageCount}");
    Console.WriteLine($"Fecha de publicación: {libro.PublishedDate.ToShortDateString()}");
    Console.WriteLine($"URL de la miniatura: {libro.ThumbnailUrl}");
    Console.WriteLine($"Estado: {libro.Status}");
    Console.WriteLine($"Autores: {string.Join(", ", libro.Authors)}");
    Console.WriteLine($"Categorías: {string.Join(", ", libro.Categories)}");
    Console.WriteLine();
  }
  // Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Título", "Cantidad de páginas", "Fecha de publicación");
  // foreach (Book libro in libros)
  // {
  //   Console.WriteLine("{0,-60} {1,15} {2,15}", libro.Title, libro.PageCount, libro.PublishedDate.ToShortDateString());
  // }
}