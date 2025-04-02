namespace FactoryMethod.Factories;
using FactoryMethod.Models;

// Fábrica de Bitcoin
public class BitcoinFactory : PagoFactory
{
  private string Wallet;

  public BitcoinFactory(string wallet)
  {
    Wallet = wallet;
  }

  public override IPago CrearPago()
  {
    return new PagoBitcoin(Wallet);
  }
}