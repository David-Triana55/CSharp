public class PrestamoRepository
{
  private readonly IAutorRepository _autorRepositoy;
  private readonly ILibroRepository _libroRepository;
  public List<Prestamo> Prestamos { get; set; } = [];

  public PrestamoRepository(IAutorRepository autorRepositoy, ILibroRepository libroRepository)
  {
    _autorRepositoy = autorRepositoy;
    _libroRepository = libroRepository;
  }

  public void AgregarPrestamo(Prestamo prestamo)
  {
    bool existeAutor = _autorRepositoy.VerificarExistencia(prestamo.Autor);
    bool existeLibro = _libroRepository.VerificarExistencia(prestamo.LibroPrestado);
    if (existeAutor && existeLibro)
    {
      _libroRepository.EstadoPrestado(prestamo.LibroPrestado);
      Prestamos.Add(prestamo);
    }
    else
    {
      Console.WriteLine("El autor no existe o el libro no existe");
    }
  }


  public void DevolverPrestamo(int indice)
  {
    if (indice < 0 || indice >= Prestamos.Count)
    {
      Console.WriteLine("Índice inválido.");
      return;
    }

    if (Prestamos[indice].FechaDevolucion != null)
    {
      Console.WriteLine("Libro ya devuelto");
      return;
    }

    Prestamos[indice].FechaDevolucion = DateTime.Now;
    _libroRepository.EstadoDisponible(Prestamos[indice].LibroPrestado);

  }

  public List<Prestamo> ObtenerPrestamos()
  {
    return Prestamos;
  }

}