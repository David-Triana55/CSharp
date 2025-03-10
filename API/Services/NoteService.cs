// contiene toda la logica y se encargan de realizar las operaciones de la base de datos
// los controladores de la aplicación se encargan de llamar a los servicios
namespace API.Services;

using System.Collections;
using API.Models;
public class NoteService : INoteService
{
  NotesContext _context;

  public NoteService(NotesContext Dbcontext)
  {
    _context = Dbcontext; // inyeccion de dependencia por interfaces
  }


  public IEnumerable<Note> Get()
  {
    return _context.Notes;
  }

  // create note
  public async Task Create(Note note)
  {
    await _context.Notes.AddAsync(note);
    await _context.SaveChangesAsync();
  }

  // update note

  public async Task Update(Guid id, Note note)
  {
    Note existNote = await _context.Notes.FindAsync(id);

    if (existNote != null)
    {

      existNote.Title = note.Title;
      existNote.Description = note.Description;
      existNote.CreatedAt = DateTime.UtcNow;
      existNote.Priority = note.Priority;
      existNote.IsActive = note.IsActive;

      await _context.SaveChangesAsync();
    }
  }

  // delete note

  public async Task<bool> Remove(Guid id)
  {
    Note existNote = await _context.Notes.FindAsync(id);

    if (existNote == null)
    {
      return false; // La nota no existe
    }

    _context.Notes.Remove(existNote);
    await _context.SaveChangesAsync();

    return true;
  }

}
public interface INoteService
{
  IEnumerable<Note> Get();
  Task Create(Note note);
  Task Update(Guid id, Note note);
  Task<bool> Remove(Guid id);
}


