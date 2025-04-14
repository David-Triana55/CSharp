namespace LibraryAPI.Domain.Entities.ValueObjects;

public class AuthorId
{
  public Guid Value { get; }

  public AuthorId(Guid value)
  {
    if (value == Guid.Empty)
      throw new ArgumentException("Author can't be empty");
    Value = value;
  }

}
