namespace AbstractFactory.Models;

public class MotoCombustion : IMoto
{
  public void Acelerar() => Console.WriteLine("Moto de combustión acelerando con gasolina.");
}