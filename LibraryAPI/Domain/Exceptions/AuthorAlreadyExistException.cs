namespace LibraryAPI.Domain.Exceptions;

using LibraryAPI.Domain.Common;

public class AuthorAlreadyExistException : Exception
{
  public AuthorAlreadyExistException() : base(ErrorMessages.AuthorAlreadyExists) { }
}