namespace AbstractFactory.Factories;
using AbstractFactory.Models;
// Fábrica concreta para vehículos de combustión

public class CombustionFactory : ITransporteFactory
{
  public ICarro CrearCarro() => new CarroCombustion();
  public IMoto CrearMoto() => new MotoCombustion();
}