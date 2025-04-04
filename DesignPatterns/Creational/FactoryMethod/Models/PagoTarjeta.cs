namespace FactoryMethod.Models;

// Pago con Tarjeta de Crédito
public class PagoTarjeta : IPago
{
  private string numeroTarjeta;
  private string cvv;

  public PagoTarjeta(string numero, string clave)
  {
    numeroTarjeta = numero;
    cvv = clave;
  }

  public void ProcesarPago(decimal monto)
  {
    Console.WriteLine($"[Tarjeta] Procesando pago de {monto:C} con tarjeta {numeroTarjeta}...");
  }
}