namespace LibraryAPI.Domain.Exceptions;

using LibraryAPI.Domain.Common;

public class BookAlreadyExistException : Exception
{
  public BookAlreadyExistException() : base(ErrorMessages.BookAlreadyExists) { }
}