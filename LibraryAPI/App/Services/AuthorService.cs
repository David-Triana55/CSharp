namespace LibraryAPI.App.Services;

using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;
using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Interfaces;
using LibraryAPI.App.Interfaces;

public class AuthorService(IAuthorRepository repository) : IAuthorService
{
  readonly IAuthorRepository _repository = repository;

  public async Task<IEnumerable<Author>> GetAuthors()
  {
    return await _repository.GetAuthors();
  }

  public async Task<ResponseAuthorDto> GetAuthorId(AuthorId id)
  {
    var author = await _repository.GetAuthorId(id);

    return new ResponseAuthorDto
    {
      Id = author.Id.Value,
      Name = author.Name,
      Nationality = author.Nationality,
      Birthdate = author.Birthdate
    };
  }

  public async Task<ResponseAuthorDto> CreateAuthor(CreateAuthorDto author)
  {
    Author authorCreated = await _repository.CreateAuthor(new Author(author.Name, author.Nationality, author.Birthdate));

    return new ResponseAuthorDto
    {
      Id = authorCreated.Id.Value,
      Name = authorCreated.Name,
      Nationality = authorCreated.Nationality,
      Birthdate = authorCreated.Birthdate
    };
  }

  public async Task UpdateAuthor(AuthorId id, UpdateAuthorDto author)
  {
    await _repository.UpdateAuthor(id, new Author(author.Name, author.Nationality, author.Birthdate));
  }

  public async Task DeleteAuthor(AuthorId id)
  {
    await _repository.DeleteAuthor(id);
  }
}



