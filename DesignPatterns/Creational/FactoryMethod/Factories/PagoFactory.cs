namespace FactoryMethod.Factories;
using FactoryMethod.Models;

// Fábrica abstracta
public abstract class PagoFactory
{
  public abstract IPago CrearPago();
}