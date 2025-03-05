using API.Models;
using Microsoft.EntityFrameworkCore;
public class TaskContext : DbContext
{
  public DbSet<Category> Categories { get; set; }// representan tablas en la base de datos
  public DbSet<API.Models.Task> Tasks { get; set; }

  // Configuración de la base de datos 
  public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    // Seed de datos en la tabla Categorias
    List<Category> categoriasInit = new List<Category>();
    categoriasInit.Add(new Category() { Id = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45507"), Name = "Test", Description = "Descripcion" });
    categoriasInit.Add(new Category() { Id = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45508"), Name = "Test2", Description = "Descripcion2" });

    // Fluent API para configurar la tabla Categorias
    modelBuilder.Entity<Category>(categoria =>
    {
      categoria.ToTable("Categories"); // nombre de la tabla
      categoria.HasKey(c => c.Id); // clave primaria
      categoria.Property(c => c.Name).IsRequired().HasMaxLength(50); // requerido y longitud máxima
      categoria.Property(c => c.Description);
      categoria.HasData(categoriasInit); // datos iniciales
    });

    // Seed de datos en la tabla Tareas
    List<API.Models.Task> tareasInit = new List<API.Models.Task>();
    tareasInit.Add(new API.Models.Task() { Id = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45509"), CategoryId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45507"), Title = "Tarea1", Description = "Descripcion1", Priority = TaskPriority.Low, CreatedAt = new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1710), IsActive = true });
    tareasInit.Add(new API.Models.Task() { Id = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45510"), CategoryId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45507"), Title = "Tarea2", Description = "Descripcion2", Priority = TaskPriority.Medium, CreatedAt = new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1717), IsActive = true });
    tareasInit.Add(new API.Models.Task() { Id = Guid.Parse("8f31917c-5d9b-42d8-89a2-8d23d72c3088"), CategoryId = Guid.Parse("264b59f3-2346-4f72-b1fc-a6842bb45508"), Title = "Tarea3", Description = "Descripcion3", Priority = TaskPriority.High, CreatedAt = new DateTime(2025, 2, 28, 19, 39, 21, 909, DateTimeKind.Utc).AddTicks(1720), IsActive = false });

    // Fluent API para configurar la tabla Tareas
    modelBuilder.Entity<API.Models.Task>(tarea =>
    {
      tarea.ToTable("Tasks"); // nombre de la tabla
      tarea.HasKey(t => t.Id); // clave primaria
      tarea.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(c => c.CategoryId); // relacion uno a muchos
      tarea.Property(t => t.Title).IsRequired().HasMaxLength(250); // requerido y longitud máxima
      tarea.Property(t => t.Description);
      tarea.Property(t => t.Priority);
      tarea.Property(t => t.CreatedAt);
      tarea.Property(t => t.IsActive).HasDefaultValue(false); // valor por defecto
      tarea.HasData(tareasInit); // datos iniciales
    });
  }

}