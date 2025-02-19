

namespace POO.Models
{
  class AntiHeroe : SuperHeroe
  {
    public string Accion { get; }

    public AntiHeroe(int id, string name, string identidadSecreta, string ciudad, List<SuperPoder> superPoder, bool puedeVolar, string accion)
      : base(id, name, identidadSecreta, ciudad, superPoder, puedeVolar)
    {
      Accion = accion;
    }

    public void AccionAntiHeroe()
    {
      Console.WriteLine($"El antiheroe {Name} ({IdentidadSecreta}) realiza: {Accion}");
    }
  }
}
