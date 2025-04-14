namespace LibraryAPI.Infrastructure.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.Domain.Exceptions;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.Infrastructure.DB.Data;
using LibraryAPI.Infrastructure.DB.Models;
using Microsoft.EntityFrameworkCore;

public class AuthorRepository(LibraryContext context) : IAuthorRepository
{
  private readonly LibraryContext _context = context;

  public async Task<Author> CreateAuthor(Author author)
  {
    bool existAuthor = await _context.Authors.AnyAsync(a => a.Id == author.Id.Value);

    if (existAuthor)
    {
      throw new AuthorAlreadyExistException();
    }

    var authorEntity = new AuthorEntity
    {
      Id = author.Id.Value,
      Name = author.Name,
      Nationality = author.Nationality,
      Birthdate = author.Birthdate
    };

    await _context.Authors.AddAsync(authorEntity);
    await _context.SaveChangesAsync();

    var domainAuthor = new Author(
      new AuthorId(authorEntity.Id),
      authorEntity.Name,
      authorEntity.Nationality,
      authorEntity.Birthdate
    );

    return domainAuthor;
  }
  public async Task<Author> GetAuthorId(AuthorId id)
  {
    var authorEntity = await _context.Authors.FindAsync(id.Value) ?? throw new UserNotFoundException();

    var domainAuthor = new Author(
      new AuthorId(authorEntity.Id),
      authorEntity.Name,
      authorEntity.Nationality,
      authorEntity.Birthdate
    );

    return domainAuthor;
  }

  public async Task<IEnumerable<Author>> GetAuthors()
  {
    return await _context.Authors.Select(a => new Author(new AuthorId(a.Id), a.Name, a.Nationality, a.Birthdate)).ToListAsync();
  }

  public async Task UpdateAuthor(AuthorId id, Author author)
  {
    var authorExist = await _context.Authors.FindAsync(id.Value) ?? throw new AuthorNotFoundException();

    authorExist.Name = author.Name;
    authorExist.Nationality = author.Nationality;
    authorExist.Birthdate = author.Birthdate;

    await _context.SaveChangesAsync();
  }

  public async Task DeleteAuthor(AuthorId id)
  {
    var authorExist = await _context.Authors.FindAsync(id.Value) ?? throw new AuthorNotFoundException();

    _context.Authors.Remove(authorExist);
    await _context.SaveChangesAsync();
  }
}
