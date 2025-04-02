// solo puede haber una instancia de una clase en caso de intentar crear una nueva se devulve la creada anteriormente

Singleton singleton = Singleton.GetInstance();
Singleton singleton2 = Singleton.GetInstance();

singleton.mensaje = "Hola Mundo 2";
singleton2.mensaje = "Hola Mundo 3";

Console.WriteLine(singleton.mensaje);
Console.WriteLine(singleton2.mensaje);

Console.WriteLine(singleton == singleton2);


public class Singleton
{
  public static Singleton? instance;
  private static readonly object _lock = new object();
  public string mensaje = "";

  private Singleton()
  {
    mensaje = "Hola Mundo";
  }

  public static Singleton GetInstance()
  {

    if (instance == null) // si la instancia es nula se crea una nueva
    {
      lock (_lock) // se usa un lock para evitar que dos hilos creen una instancia al mismo tiempo
      {

        if (instance == null)
        {
          instance = new Singleton();
        }
      }
    }
    return instance;
  }
}