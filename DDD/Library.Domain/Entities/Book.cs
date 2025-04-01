namespace Library.Domain.Entities;

public class Book
{
  public Guid Id { get; private set; }
  public string Title { get; private set; }
  public string Author { get; private set; }
  public int AvailableCopies { get; private set; }

  private Book() { } // Constructor privado para EF

  public Book(string title, string author, int availableCopies)
  {
    Id = Guid.NewGuid();
    Title = title;
    Author = author;
    AvailableCopies = availableCopies;
  }

  public void Borrow()
  {
    if (AvailableCopies <= 0)
      throw new InvalidOperationException("No copies available.");
    AvailableCopies--;
  }

  public void Return()
  {
    AvailableCopies++;
  }
}
