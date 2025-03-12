using System.Collections;
using LibraryAPI.Data;
using LibraryAPI.DTOs;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
public class AuthorService(LibraryContext context) : IAuthorService
{
  readonly LibraryContext _context = context;

  public async Task<IEnumerable<ResponseAuthorDto>> GetAuthors()
  {
    return await _context.Authors.Select(a => new ResponseAuthorDto
    {
      Id = a.Id,
      Name = a.Name,
      Nationality = a.Nationality,
      Birthdate = a.Birthdate
    }).ToListAsync();
  }

  public async Task<ResponseAuthorDto> GetAuthorId(int id)
  {
    bool existAuthor = await _context.Authors.AnyAsync(a => a.Id == id);

    if (!existAuthor)
    {
      throw new Exception("Author doesn't exist");
    }

    return await _context.Authors
    .Where(a => a.Id == id)
    .Select(a => new ResponseAuthorDto
    {
      Id = a.Id,
      Name = a.Name,
      Nationality = a.Nationality,
      Birthdate = a.Birthdate
    }).FirstAsync();
  }

  public async Task<ResponseAuthorDto> CreateAuthor(CreateAuthorDto author)
  {
    bool existAuthor = await _context.Authors.AnyAsync(a => a.Name == author.Name);

    if (existAuthor)
    {
      throw new Exception("Author already exists");
    }

    var authorAdd = new Author
    {
      Name = author.Name,
      Nationality = author.Nationality,
      Birthdate = author.Birthdate
    };

    await _context.Authors.AddAsync(authorAdd);
    await _context.SaveChangesAsync();

    return new ResponseAuthorDto
    {
      Id = authorAdd.Id,
      Name = authorAdd.Name,
      Nationality = authorAdd.Nationality,
      Birthdate = authorAdd.Birthdate
    };
  }

  public async Task UpdateAuthor(int id, UpdateAuthorDto author)
  {
    Author editAuthor = await _context.Authors.FindAsync(id);

    if (editAuthor == null)
    {
      throw new Exception("Author doesn't exist");
    }

    editAuthor.Name = author.Name;
    editAuthor.Nationality = author.Nationality;
    editAuthor.Birthdate = author.Birthdate;

    await _context.SaveChangesAsync();
  }

  public async Task DeleteAuthor(int id)
  {
    Author editAuthor = await _context.Authors.FindAsync(id);

    if (editAuthor == null)
    {
      throw new Exception("Author doesn't exist");
    }
    _context.Authors.Remove(editAuthor);
    await _context.SaveChangesAsync();
  }
}

public interface IAuthorService
{
  Task<IEnumerable<ResponseAuthorDto>> GetAuthors();
  Task<ResponseAuthorDto> GetAuthorId(int id);
  Task<ResponseAuthorDto> CreateAuthor(CreateAuthorDto author);
  Task UpdateAuthor(int id, UpdateAuthorDto author);
  Task DeleteAuthor(int id);
}