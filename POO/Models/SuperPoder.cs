

namespace POO.Models
{
  class SuperPoder
  {
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public NivelPoder Nivel { get; set; }

    public SuperPoder(string nombre, string descripcion, NivelPoder nivel)
    {
      Nombre = nombre;
      Descripcion = descripcion;
      Nivel = nivel;
    }
  }
}
