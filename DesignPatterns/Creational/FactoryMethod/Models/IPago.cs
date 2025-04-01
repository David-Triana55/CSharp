namespace FactoryMethod.Models;

// Interfaz común para todos los métodos de pago
public interface IPago
{
  void ProcesarPago(decimal monto);
}