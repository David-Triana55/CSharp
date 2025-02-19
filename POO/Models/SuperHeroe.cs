using POO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POO.Models
{
  class SuperHeroe : Heroe, ISuperHeroe
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string IdentidadSecreta { get; set; }
    private string Ciudad { get; set; }
    private List<SuperPoder> SuperPoder { get; set; }
    private bool PuedeVolar { get; set; }

    public SuperHeroe(int id, string name, string identidadSecreta, string ciudad, List<SuperPoder> superPoder, bool puedeVolar)
    {
      Id = id;
      Name = name;
      IdentidadSecreta = identidadSecreta;
      Ciudad = ciudad;
      SuperPoder = superPoder;
      PuedeVolar = puedeVolar;
    }

    public override void SalvarMundo()
    {
      Console.WriteLine($"{Name} ({IdentidadSecreta}) has salvado el mundo");
    }

    public void MostrarInfomacion()
    {
      Console.WriteLine($"Nombre: {Name}, Identidad: {IdentidadSecreta}, Ciudad: {Ciudad}");
      Console.WriteLine("Poderes:");
      foreach (var poder in SuperPoder)
      {
        Console.WriteLine($"  - {poder.Nombre}: {poder.Descripcion} (Nivel {poder.Nivel})");
      }
      Console.WriteLine();
    }
    //public string GetSuperHeroe()
    //{
    //  StringBuilder sb = new StringBuilder();
    //  sb.AppendLine("hola");
    //  return sb.ToString();
    //} 
  }

}
