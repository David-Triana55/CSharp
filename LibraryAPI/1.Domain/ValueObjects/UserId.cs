namespace LibraryAPI.Domain.Entities.ValueObjects;

public class UserId
{
  public Guid Value { get; }

  public UserId(Guid value)
  {
    if (value == Guid.Empty)
      throw new ArgumentException("User can't be empty");
    Value = value;
  }

}
