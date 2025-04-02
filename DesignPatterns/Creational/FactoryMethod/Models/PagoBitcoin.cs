namespace FactoryMethod.Models;

// Pago con Bitcoin
public class PagoBitcoin : IPago
{
  private string direccionWallet;

  public PagoBitcoin(string wallet)
  {
    direccionWallet = wallet;
  }

  public void ProcesarPago(decimal monto)
  {
    Console.WriteLine($"[Bitcoin] Procesando pago de {monto:C} a la dirección {direccionWallet}...");
  }
}