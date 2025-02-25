public interface IAutorRepository
{
  public List<Autor> ObtenerAutores();
  public bool VerificarExistencia(string nombre);
}