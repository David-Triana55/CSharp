namespace LibraryAPI.Domain.Entities.ValueObjects;

public class LoanId
{
  public Guid Value { get; }

  public LoanId(Guid value)
  {
    if (value == Guid.Empty)
      throw new ArgumentException("loan can't be empty");
    Value = value;
  }

}
