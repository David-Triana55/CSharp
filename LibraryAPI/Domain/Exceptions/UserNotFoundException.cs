using LibraryAPI.Domain.Common;

namespace LibraryAPI.Domain.Exceptions
{
  public class UserNotFoundException : Exception
  {

    public UserNotFoundException() : base(ErrorMessages.UserNotFound) { }
  }
}
