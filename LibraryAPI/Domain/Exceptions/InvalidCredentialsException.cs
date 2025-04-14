using LibraryAPI.Domain.Common;

namespace LibraryAPI.Domain.Exceptions;

public class InvalidCredentialsException : Exception
{
  public InvalidCredentialsException() : base(ErrorMessages.InvalidCredentials) { }
}