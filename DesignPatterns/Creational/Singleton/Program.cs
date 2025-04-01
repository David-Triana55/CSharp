// solo puede haber una instancia de una clase en caso de intentar crear una nueva se devulve la creada anteriormente

Singleton singleton = Singleton.getInstance();
Singleton singleton2 = Singleton.getInstance();

singleton.mensaje = "Hola Mundo 2";

Console.WriteLine(singleton.mensaje);
Console.WriteLine(singleton2.mensaje);

Console.WriteLine(singleton == singleton2);




public class Singleton
{
  public static Singleton? instance;
  public string mensaje = "";

  private Singleton()
  {
    mensaje = "Hola Mundo";
  }

  public static Singleton getInstance()
  {
    if (instance == null)
    {
      instance = new Singleton();
    }
    return instance;
  }
}