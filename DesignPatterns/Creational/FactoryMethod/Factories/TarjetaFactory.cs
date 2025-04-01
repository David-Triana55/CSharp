namespace FactoryMethod.Factories;
using FactoryMethod.Models;

// Fábrica de Tarjeta de Crédito
public class TarjetaFactory : PagoFactory
{
  private string numero;
  private string cvv;

  public TarjetaFactory(string numero, string cvv)
  {
    this.numero = numero;
    this.cvv = cvv;
  }

  public override IPago CrearPago()
  {
    return new PagoTarjeta(numero, cvv);
  }
}