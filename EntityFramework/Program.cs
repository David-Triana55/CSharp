using EntityFramework;
using EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(opt => opt.UseInMemoryDatabase("TareasDB"));
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));// 💡 Configurar el servicio de DbContext ANTES de `builder.Build()`

var app = builder.Build();

// Rutas
app.MapGet("/", () => "Hello World!");

// categorias

// retornar todas las categorias

app.MapGet("/api/categorias", async ([FromServices] TareasContext dbContext) =>
{
  try
  {
    var categorias = await dbContext.Categorias.ToListAsync();
    return Results.Ok(categorias);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// retorna una categoria por su id

app.MapGet("/api/categorias/{categoriaId}", async ([FromServices] TareasContext dbContext, Guid categoriaId) =>
{
  try
  {
    var categoria = await dbContext.Categorias.FindAsync(categoriaId);
    return Results.Ok(categoria);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// se crea una nueva categoria

app.MapPost("/api/categorias", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria) =>
{
  try
  {
    categoria.CategoriaId = Guid.NewGuid();
    await dbContext.Categorias.AddAsync(categoria);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/categorias/{categoria.CategoriaId}", categoria);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// Actualizar una categoria

app.MapPut("/api/categorias/{categoriaId}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid categoriaId, [FromBody] Categoria categoria) =>
{
  try
  {
    var categoriaOriginal = await dbContext.Categorias.FindAsync(categoriaId);
    if (categoriaOriginal != null)
    {
      categoriaOriginal.Nombre = categoria.Nombre;
      categoriaOriginal.Descripcion = categoria.Descripcion;
      categoriaOriginal.Resumen = categoria.Resumen;
      await dbContext.SaveChangesAsync();
      return Results.Ok(categoriaOriginal);
    }
    return Results.NotFound();
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// eliminar una categoria

app.MapDelete("/api/categorias/{categoriaId}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid categoriaId) =>
{
  try
  {
    var categoria = await dbContext.Categorias.FindAsync(categoriaId);
    if (categoria != null)
    {
      dbContext.Categorias.Remove(categoria);
      await dbContext.SaveChangesAsync();
      return Results.Ok();
    }
    return Results.NotFound("Categoria no encontrada");
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});


//! retornar todas las tareas

// FromServices nos trae el sercicio de configuracion de TareasContext
// retornar todas las tareas
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
  try
  {
    var tareas = await dbContext.Tareas.Include(p => p.Categoria).ToListAsync();
    return Results.Ok(tareas);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// retornar una tarea por su id

app.MapGet("/api/tareas/{tareaId}", async ([FromServices] TareasContext dbContext, Guid tareaId) =>
{
  try
  {
    var tarea = await dbContext.Tareas.FindAsync(tareaId);
    return Results.Ok(tarea);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// se crea una nueva tarea
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  try
  {
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.UtcNow;
    await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/tareas/{tarea.TareaId}", tarea);
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});


// Actualizar una tarea

app.MapPut("/api/tareas/{tareaId}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid tareaId, [FromBody] Tarea tarea) =>
{
  try
  {
    var tareaOriginal = await dbContext.Tareas.FindAsync(tareaId);
    if (tareaOriginal != null)
    {
      tareaOriginal.Titulo = tarea.Titulo;
      tareaOriginal.Descripcion = tarea.Descripcion;
      tareaOriginal.PrioridadTarea = tarea.PrioridadTarea;
      tareaOriginal.FechaCreacion = tarea.FechaCreacion;
      tareaOriginal.IsActive = tarea.IsActive;
      tareaOriginal.Resumen = tarea.Resumen;
      await dbContext.SaveChangesAsync();
      return Results.Redirect($"/api/tareas/{tareaOriginal.TareaId}");
    }

    return Results.NotFound("Tarea no encontrada");
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});

// eliminar una tarea

app.MapDelete("/api/tareas/{tareaId}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid tareaId) =>
{
  try
  {
    var tarea = await dbContext.Tareas.FindAsync(tareaId);
    if (tarea != null)
    {
      dbContext.Tareas.Remove(tarea);
      await dbContext.SaveChangesAsync();
      return Results.Ok();
    }
    return Results.NotFound("Tarea no encontrada");
  }
  catch (Exception ex)
  {
    return Results.BadRequest(ex.Message);
  }
});
app.Run();
