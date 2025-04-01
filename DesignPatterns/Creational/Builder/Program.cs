/*
permite construir objetos complejos paso a paso, proporcionando un proceso controlado 
para la creación del objeto. Su principal función es simplificar la construcción de objetos 
con múltiples propiedades, especialmente cuando tienen muchos parámetros o cuando 
algunos de estos parámetros son opcionales
*/

try
{
  Computer computer = Computer.Create()
      .SetName("Dell")
      .SetCores(4)
      .SetMemory(16)
      .SetDisks(1)
      .SetGpu("Nvidia")
      .SetProcessor("Intel")
      .SetMonitor("LG")
      .SetMouse("Microsoft")
      .SetKeyboard("Apple")
      .SetPowerSupply("Corsair")
      .Build();

  Computer computer1 = Computer.Create()
      .SetName("HP")
      .SetCores(2)
      .SetMemory(8)
      .SetDisks(2)
      .SetGpu("AMD")
      .SetProcessor("AMD")
      .SetMonitor("Samsung")
      .SetMouse("Microsoft")
      .SetKeyboard("Apple")
      .SetPowerSupply("Corsair")
      .Build();


  List<Computer> computers = new List<Computer> { computer, computer1 };
  foreach (var c in computers)
  {
    Console.WriteLine("Computer:");
    Console.WriteLine($"Name: {c.Name}");
    Console.WriteLine($"Cores: {c.Cores}");
    Console.WriteLine($"Memory: {c.Memory}");
    Console.WriteLine($"Disks: {c.Disks}");
    Console.WriteLine($"GPU: {c.Gpu}");
    Console.WriteLine($"Processor: {c.Processor}");
    Console.WriteLine($"Monitor: {c.Monitor}");
    Console.WriteLine($"Mouse: {c.Mouse}");
    Console.WriteLine($"Keyboard: {c.Keyboard}");
    Console.WriteLine($"Power Supply: {c.PowerSupply}");
    Console.WriteLine();
  }


}
catch (ArgumentException ex)
{
  Console.WriteLine($"Error: {ex.Message}");
}
