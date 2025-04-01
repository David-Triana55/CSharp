// !Producto Abstracto 1: Botón
public interface IButton
{
  void Render();
}

// !Producto Abstracto 2: Checkbox
public interface ICheckbox
{
  void Toggle();
}

// !Fábrica abstracta que crea familias de objetos (botón y checkbox)
public interface IGUIFactory
{
  IButton CreateButton();
  ICheckbox CreateCheckbox();
}

// !Implementaciones concretas para Windows
public class WindowsButton : IButton
{
  public void Render() => Console.WriteLine("Renderizando botón de Windows");
}

public class WindowsCheckbox : ICheckbox
{
  public void Toggle() => Console.WriteLine("Toggling checkbox de Windows");
}

// !Implementaciones concretas para macOS
public class MacButton : IButton
{
  public void Render() => Console.WriteLine("Renderizando botón de macOS");
}

public class MacCheckbox : ICheckbox
{
  public void Toggle() => Console.WriteLine("Toggling checkbox de macOS");
}

// !Fábrica concreta para Windows
public class WindowsFactory : IGUIFactory
{
  public IButton CreateButton() => new WindowsButton();
  public ICheckbox CreateCheckbox() => new WindowsCheckbox();
}

// !Fábrica concreta para macOS
public class MacFactory : IGUIFactory
{
  public IButton CreateButton() => new MacButton();
  public ICheckbox CreateCheckbox() => new MacCheckbox();
}

// !Aplicación que utiliza la fábrica abstracta
public class Application
{
  private readonly IButton _button;
  private readonly ICheckbox _checkbox;

  public Application(IGUIFactory factory)
  {
    _button = factory.CreateButton();
    _checkbox = factory.CreateCheckbox();
  }

  public void RenderUI()
  {
    _button.Render();
    _checkbox.Toggle();
  }
}
class Program
{
  static void Main()
  {
    IGUIFactory factory;

    string os = "mac"; // Esto podría venir de una configuración
    if (os == "windows")
      factory = new WindowsFactory();
    else
      factory = new MacFactory();

    var app = new Application(factory);
    app.RenderUI();
  }
}
