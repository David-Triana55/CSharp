namespace LibraryAPI.Domain.Interfaces;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;

public interface IAuthorRepository
{
  Task<IEnumerable<Author>> GetAuthors();
  Task<Author> GetAuthorId(AuthorId id);
  Task<Author> CreateAuthor(Author author);
  Task UpdateAuthor(AuthorId id, Author author);

  Task DeleteAuthor(AuthorId id);
}
