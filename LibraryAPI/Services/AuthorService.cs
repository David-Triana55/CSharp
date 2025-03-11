using System.Collections;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
public class AuthorService : IAuthorService
{
  readonly LibraryContext _context;
  public AuthorService(LibraryContext context)
  {
    _context = context;
  }
  // listar autores
  public IEnumerable<Author> GetAuthors()
  {
    return _context.Authors.Include(b => b.Books).ToList();
  }

  // agregar autores
  public async Task Add(CreateAuthorDto author)
  {
    var authorAdd = new Author
    {
      Name = author.Name,
      Nationality = author.Nationality,
      Birthdate = author.Birthdate
    };

    await _context.Authors.AddAsync(authorAdd);
    await _context.SaveChangesAsync();
  }

  // editar autores
  public async Task Edit(int id, UpdateAuthor author)
  {
    Author editAuthor = await _context.Authors.FindAsync(id);

    if (editAuthor != null)
    {
      editAuthor.Name = author.Name;
      editAuthor.Nationality = author.Nationality;
      editAuthor.Birthdate = author.Birthdate;

      await _context.SaveChangesAsync();
    }
  }
  // eliminar autores
  public async Task Remove(int id)
  {
    Author editAuthor = await _context.Authors.FindAsync(id);

    if (editAuthor != null)
    {
      _context.Authors.Remove(editAuthor);
      await _context.SaveChangesAsync();
    }
  }
}

public interface IAuthorService
{
  IEnumerable<Author> GetAuthors();
  Task Add(CreateAuthorDto author);
  Task Edit(int id, UpdateAuthor author);
  Task Remove(int idx);
}