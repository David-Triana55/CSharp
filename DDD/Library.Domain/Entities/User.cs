namespace Library.Domain.Entities;

public class User
{
  public Guid Id { get; private set; }
  public string Name { get; private set; }

  private User() { } // Constructor privado para EF

  public User(string name)
  {
    Id = Guid.NewGuid();
    Name = name;
  }
}
