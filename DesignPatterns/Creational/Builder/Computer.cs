
public class Computer
{
  public string Name { get; private set; }
  public int Cores { get; private set; }
  public int Memory { get; private set; }
  public int Disks { get; private set; }
  public string Gpu { get; private set; }
  public string Processor { get; private set; }
  public string Monitor { get; private set; }
  public string Mouse { get; private set; }
  public string Keyboard { get; private set; }
  public string PowerSupply { get; private set; }

  // Constructor privado para forzar el uso del Builder
  private Computer() { }

  // Builder en la misma clase
  public class Builder
  {
    private readonly Computer _computer = new Computer();

    public Builder SetName(string name)
    {
      if (string.IsNullOrEmpty(name))
        throw new ArgumentException("Name cannot be null or empty");
      _computer.Name = name;
      return this;
    }

    public Builder SetCores(int cores)
    {
      if (cores <= 0)
        throw new ArgumentException("Cores must be greater than 0");
      _computer.Cores = cores;
      return this;
    }

    public Builder SetMemory(int memory)
    {
      if (memory <= 0)
        throw new ArgumentException("Memory must be greater than 0");
      _computer.Memory = memory;
      return this;
    }

    public Builder SetDisks(int disks)
    {
      if (disks < 0)
        throw new ArgumentException("Disks cannot be negative");
      _computer.Disks = disks;
      return this;
    }

    public Builder SetGpu(string gpu)
    {
      if (string.IsNullOrEmpty(gpu))
        throw new ArgumentException("GPU cannot be null or empty");
      _computer.Gpu = gpu;
      return this;
    }

    public Builder SetProcessor(string processor)
    {
      if (string.IsNullOrEmpty(processor))
        throw new ArgumentException("Processor cannot be null or empty");
      _computer.Processor = processor;
      return this;
    }

    public Builder SetMonitor(string monitor)
    {
      _computer.Monitor = monitor;  // Puede ser nulo
      return this;
    }

    public Builder SetMouse(string mouse)
    {
      _computer.Mouse = mouse;  // Puede ser nulo
      return this;
    }

    public Builder SetKeyboard(string keyboard)
    {
      _computer.Keyboard = keyboard;  // Puede ser nulo
      return this;
    }

    public Builder SetPowerSupply(string powerSupply)
    {
      if (string.IsNullOrEmpty(powerSupply))
        throw new ArgumentException("Power Supply cannot be null or empty");
      _computer.PowerSupply = powerSupply;
      return this;
    }

    public Computer Build() => _computer;
  }

  public static Builder Create() => new Builder();
}
