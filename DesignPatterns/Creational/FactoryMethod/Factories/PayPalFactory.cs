namespace FactoryMethod.Factories;
using FactoryMethod.Models;

// Fábrica de PayPal
public class PayPalFactory : PagoFactory
{
  public override IPago CrearPago()
  {
    return new PagoPayPal();
  }
}