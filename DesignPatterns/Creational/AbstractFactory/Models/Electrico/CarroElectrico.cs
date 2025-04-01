namespace AbstractFactory.Models;

public class CarroElectrico : ICarro
{
  public void Encender() => Console.WriteLine("Carro eléctrico encendido con batería.");
}