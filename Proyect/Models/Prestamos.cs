public class Prestamo
{

  public string LibroPrestado { get; set; }
  public string Autor { get; set; }
  public DateTime FechaPrestamo { get; set; }
  public DateTime? FechaDevolucion { get; set; } = null;

  public Prestamo(string libroPrestado, string autor, DateTime fechaPrestamo, DateTime fechaDevolucion)
  {
    LibroPrestado = libroPrestado;
    Autor = autor;
    FechaPrestamo = fechaPrestamo;
    FechaDevolucion = fechaDevolucion;
  }

  public Prestamo(string libroPrestado, string autor, DateTime fechaPrestamo)
  {
    LibroPrestado = libroPrestado;
    Autor = autor;
    FechaPrestamo = fechaPrestamo;
  }
}
