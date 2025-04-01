namespace AbstractFactory.Factories;
using AbstractFactory.Models;

// Fábrica concreta para vehículos eléctricos
public class ElectricoFactory : ITransporteFactory
{
  public ICarro CrearCarro() => new CarroElectrico();
  public IMoto CrearMoto() => new MotoElectrica();
}