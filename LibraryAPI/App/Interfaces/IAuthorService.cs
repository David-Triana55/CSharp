using LibraryAPI.App.DTOs;
using LibraryAPI.Domain.Entities;
using LibraryAPI.Domain.Entities.ValueObjects;

namespace LibraryAPI.App.Interfaces;


public interface IAuthorService
{
  Task<IEnumerable<Author>> GetAuthors();
  Task<ResponseAuthorDto> GetAuthorId(AuthorId id);
  Task<ResponseAuthorDto> CreateAuthor(CreateAuthorDto author);
  Task UpdateAuthor(AuthorId id, UpdateAuthorDto author);
  Task DeleteAuthor(AuthorId id);
}