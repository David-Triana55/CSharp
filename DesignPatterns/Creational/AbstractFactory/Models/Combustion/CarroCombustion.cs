namespace AbstractFactory.Models;
public class CarroCombustion : ICarro
{
  public void Encender() => Console.WriteLine("Carro de combustión encendido con gasolina.");
}