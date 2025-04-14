using LibraryAPI.Domain.Common;

namespace LibraryAPI.Domain.Exceptions
{
  public class BookIsBorrowedException : Exception
  {
    public BookIsBorrowedException() : base(ErrorMessages.BookIsBorrowed) { }
  }
}
