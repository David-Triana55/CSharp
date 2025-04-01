namespace Library.Infrastructure;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
  public DbSet<Book> Books { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<Loan> Loans { get; set; }

  public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
      : base(options)
  { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Book>()
        .Property(b => b.Title)
        .IsRequired()
        .HasMaxLength(200);

    modelBuilder.Entity<Book>()
        .Property(b => b.Author)
        .IsRequired()
        .HasMaxLength(100);

    modelBuilder.Entity<Loan>()
        .HasOne<Book>()
        .WithMany()
        .HasForeignKey(l => l.BookId);

    modelBuilder.Entity<Loan>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(l => l.UserId);
  }
}
