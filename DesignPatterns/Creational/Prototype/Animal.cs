// clonacion superficial => clonacion de los valores de los atributos
// clonacion profunda => clonacion de los valores de los atributos y de los objetos que son atributos de la clase

using System.ComponentModel;

class Person : ICloneable
{
  public int Edad { get; set; }
  public string Nombre { get; set; }
  public string Apellido { get; set; }

  public Adrress Direccion { get; set; }

  // public object Clone()
  // {
  //   return MemberwiseClone(); // Clonacion superficial
  // }

  public object Clone()
  {
    Person clone = this.MemberwiseClone() as Person;
    Adrress direccion = new Adrress();
    direccion.Calle = this.Direccion.Calle;
    direccion.Ciudad = this.Direccion.Ciudad;
    clone.Direccion = direccion; // Clonacion profunda
    return clone;
  }

}

class Adrress
{
  public string Calle { get; set; }
  public string Ciudad { get; set; }
}
