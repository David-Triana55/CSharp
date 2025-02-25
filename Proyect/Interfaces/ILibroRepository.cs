public interface ILibroRepository
{
  public List<Libro> ObtenerLibros();
  public bool VerificarExistencia(string titulo);
  public void EstadoDisponible(string titulo);
  public void EstadoPrestado(string titulo);
}