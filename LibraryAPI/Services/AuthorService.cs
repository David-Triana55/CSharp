using System.Collections;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
public class AuthorService : IAuthorService
{
  LibraryContext _libraryContext;
  public AuthorService(LibraryContext context)
  {
    _libraryContext = context;
  }
  // listar autores
  public IEnumerable<Author> GetAuthors()
  {
    return _libraryContext.Authors.Include(b => b.Books).ToList();
  }

  // agregar autores
  public async Task Add(Author author)
  {
    await _libraryContext.Authors.AddAsync(author);
    await _libraryContext.SaveChangesAsync();
  }

  // editar autores
  public async Task Edit(int id, Author author)
  {
    Author editAuthor = await _libraryContext.Authors.FindAsync(id);

    if (editAuthor != null)
    {
      editAuthor.Name = author.Name;
      editAuthor.Nationality = author.Nationality;
      editAuthor.Birthdate = author.Birthdate;

      await _libraryContext.SaveChangesAsync();
    }
  }
  // eliminar autores
  public async Task Remove(int id)
  {
    Author editAuthor = await _libraryContext.Authors.FindAsync(id);

    if (editAuthor != null)
    {
      _libraryContext.Authors.Remove(editAuthor);
      await _libraryContext.SaveChangesAsync();
    }
  }
}

public interface IAuthorService
{
  IEnumerable<Author> GetAuthors();
  Task Add(Author author);
  Task Edit(int id, Author author);
  Task Remove(int idx);
}