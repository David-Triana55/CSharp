/*
El patrón Factory es un patrón de diseño creacional que se utiliza para delegar la creación de objetos a una clase en lugar de instanciarlos directamente

Evita la creación directa de objetos con new, facilitando el mantenimiento y la extensibilidad.

Permite la encapsulación de la lógica de creación, centralizando la instanciación en un solo lugar.

Facilita la implementación de cambios sin afectar el código cliente.

Mejora la reutilización del código y reduce la duplicación de lógica de creación.

*/

using FactoryMethod.Factories;
using FactoryMethod.Models;


// Cliente elige método de pago
Console.WriteLine("Seleccione método de pago: 1) PayPal  2) Tarjeta  3) Bitcoin");
int opcion = int.Parse(Console.ReadLine());

PagoFactory factory;

switch (opcion)
{
  case 1:
    factory = new PayPalFactory();
    break;
  case 2:
    Console.Write("Ingrese número de tarjeta: ");
    string numTarjeta = Console.ReadLine();
    Console.Write("Ingrese CVV: ");
    string cvv = Console.ReadLine();
    factory = new TarjetaFactory(numTarjeta, cvv);
    break;
  case 3:
    Console.Write("Ingrese dirección de Bitcoin: ");
    string wallet = Console.ReadLine();
    factory = new BitcoinFactory(wallet);
    break;
  default:
    Console.WriteLine("Opción no válida.");
    return;
}

// Crear pago usando la fábrica
IPago pago = factory.CrearPago();
pago.ProcesarPago(100.00m); // Simula un pago de 100
