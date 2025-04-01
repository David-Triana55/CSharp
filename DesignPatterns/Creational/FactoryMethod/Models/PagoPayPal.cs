namespace FactoryMethod.Models;

// Pago con paypal
public class PagoPayPal : IPago
{
  private string apiKey;

  public PagoPayPal()
  {
    // Simulamos que obtenemos la API Key de un servicio seguro
    apiKey = "API_KEY_SECRETA";
  }

  public void ProcesarPago(decimal monto)
  {
    Console.WriteLine($"[PayPal] Procesando pago de {monto:C} con API Key {apiKey}...");
  }
}