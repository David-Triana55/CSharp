namespace FactoryMethod.Factories;
using FactoryMethod.Models;

// Fábrica de Bitcoin
public class BitcoinFactory : PagoFactory
{
  private string wallet;

  public BitcoinFactory(string wallet)
  {
    this.wallet = wallet;
  }

  public override IPago CrearPago()
  {
    return new PagoBitcoin(wallet);
  }
}