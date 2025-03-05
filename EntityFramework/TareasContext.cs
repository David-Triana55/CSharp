namespace EntityFramework;

using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
public class TareasContext : DbContext
{
  public DbSet<Categoria> Categorias { get; set; }// representan tablas en la base de datos
  public DbSet<Tarea> Tareas { get; set; }

  // Configuración de la base de datos 
  public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Seed de datos en la tabla Categorias
    List<Categoria> categoriasInit = new List<Categoria>();
    categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45507"), Nombre = "Test", Descripcion = "Descripcion", Resumen = "Resumen" });
    categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45508"), Nombre = "Test2", Descripcion = "Descripcion2", Resumen = "Resumen2" });

    // Fluent API para configurar la tabla Categorias
    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("Categorias"); // nombre de la tabla
      categoria.HasKey(c => c.CategoriaId); // clave primaria
      categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(50); // requerido y longitud máxima
      categoria.Property(c => c.Descripcion);
      categoria.Property(c => c.Resumen).IsRequired().HasMaxLength(250);
      categoria.HasData(categoriasInit); // datos iniciales
    });

    // Seed de datos en la tabla Tareas
    List<Tarea> tareasInit = new List<Tarea>();
    tareasInit.Add(new Tarea() { TareaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45509"), CategoriaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45507"), Titulo = "Tarea1", Descripcion = "Descripcion1", PrioridadTarea = Prioridad.Baja, FechaCreacion = new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1710), IsActive = true, Resumen = "Resumen1" });
    tareasInit.Add(new Tarea() { TareaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45510"), CategoriaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45507"), Titulo = "Tarea2", Descripcion = "Descripcion2", PrioridadTarea = Prioridad.Media, FechaCreacion = new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1717), IsActive = true, Resumen = "Resumen2" });
    tareasInit.Add(new Tarea() { TareaId = Guid.Parse("8f31917c-5d9b-42d8-89a2-8d23d72c3088"), CategoriaId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45508"), Titulo = "Tarea3", Descripcion = "Descripcion3", PrioridadTarea = Prioridad.Alta, FechaCreacion = new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1720), IsActive = false, Resumen = "Resumen3" });

    // Fluent API para configurar la tabla Tareas
    modelBuilder.Entity<Tarea>(tarea =>
    {
      tarea.ToTable("Tareas"); // nombre de la tabla
      tarea.HasKey(t => t.TareaId); // clave primaria
      tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(c => c.CategoriaId); // relacion uno a muchos
      tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(250); // requerido y longitud máxima
      tarea.Property(t => t.Descripcion);
      tarea.Property(t => t.PrioridadTarea);
      tarea.Property(t => t.FechaCreacion);
      tarea.Property(t => t.IsActive).HasDefaultValue(false); // valor por defecto
      tarea.Ignore(p => p.Resumen); // ignorar propiedad
      tarea.HasData(tareasInit); // datos iniciales
    });
  }

}