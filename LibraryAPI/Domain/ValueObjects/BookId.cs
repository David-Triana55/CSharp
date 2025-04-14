namespace LibraryAPI.Domain.Entities.ValueObjects;

public class BookId
{
  public Guid Value { get; }

  public BookId(Guid value)
  {
    if (value == Guid.Empty)
      throw new ArgumentException("Book can't be empty");
    Value = value;
  }

}
