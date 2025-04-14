using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Enums;

namespace LibraryAPI.Domain.Entities;
public class Book
{
  public BookId Id { get; private set; }
  public Guid AuthorId { get; private set; }
  public string Title { get; private set; }
  public string Genre { get; private set; }
  public DateOnly PublicationDate { get; private set; }
  public EBookStatus Status { get; private set; }
  public Author? Author { get; set; }


  public Book(AuthorId authorId, string title, string genre, DateOnly publicationDate, EBookStatus status)
  {
    if (string.IsNullOrWhiteSpace(title))
      throw new ArgumentException("Title is required");

    if (publicationDate > DateOnly.FromDateTime(DateTime.UtcNow))
      throw new ArgumentException("Publication date cannot be in the future");

    Id = new BookId(Guid.NewGuid());
    AuthorId = authorId.Value;
    Title = title;
    Genre = genre;
    PublicationDate = publicationDate;
    Status = status;
  }

  // Constructor para reconstrucción desde la DB
  public Book(BookId id, AuthorId authorId, string title, string genre, DateOnly publicationDate, EBookStatus status)
  {
    Id = id;
    AuthorId = authorId.Value;
    Title = title;
    Genre = genre;
    PublicationDate = publicationDate;
    Status = status;
  }

  public bool IsBorrowed()
  {
    if (Status == EBookStatus.borrowed)
    {
      return true;
    }
    else
    {
      return false;
    }
  }

}

