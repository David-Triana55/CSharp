using LibraryAPI.Domain.Common;

namespace LibraryAPI.Domain.Exceptions
{
  public class BookNotFoundException : Exception
  {
    public BookNotFoundException() : base(ErrorMessages.BookNotFound) { }
  }
}
