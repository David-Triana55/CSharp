using LibraryAPI.Domain.Common;

namespace LibraryAPI.Domain.Exceptions
{
  public class AuthorNotFoundException : Exception
  {

    public AuthorNotFoundException() : base(ErrorMessages.UserNotFound) { }
  }
}
