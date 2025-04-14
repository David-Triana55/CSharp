using LibraryAPI.Domain.Common;

namespace LibraryAPI.Domain.Exceptions
{
  public class LoanNotFoundException : Exception
  {
    public LoanNotFoundException() : base(ErrorMessages.LoanNotFound) { }
  }
}
