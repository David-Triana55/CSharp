namespace AbstractFactory.Models;
public class MotoElectrica : IMoto
{
  public void Acelerar() => Console.WriteLine("Moto eléctrica acelerando en modo silencioso.");
}
