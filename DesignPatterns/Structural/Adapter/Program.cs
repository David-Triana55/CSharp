class FahrenheitSensor
{
  public double GetTemperatureInFahrenheit(double fahrenheit)
  {
    return fahrenheit;
  }
}


public interface ITemperatureTarget
{
  double GetTemperatureInCelsius(double fahrenheit);
}


class TemperatureAdapter : ITemperatureTarget
{
  private readonly FahrenheitSensor _fahrenheitSensor;

  public TemperatureAdapter(FahrenheitSensor fahrenheitSensor)
  {
    _fahrenheitSensor = fahrenheitSensor;
  }

  public double GetTemperatureInCelsius(double fahrenheit)
  {
    var celsius = (_fahrenheitSensor.GetTemperatureInFahrenheit(fahrenheit) - 32) * 5 / 9;
    return celsius;
  }
}
class Program
{
  static void Main()
  {
    FahrenheitSensor fahrenheitSensor = new FahrenheitSensor();
    ITemperatureTarget temperatureTarget = new TemperatureAdapter(fahrenheitSensor);

    Console.WriteLine("El sistema solo acepta temperaturas en Celsius:");
    Console.WriteLine($"Temperatura en Celsius: {temperatureTarget.GetTemperatureInCelsius(67):F2}°C");
  }
}
