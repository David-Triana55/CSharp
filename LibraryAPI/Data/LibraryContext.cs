using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
namespace LibraryAPI.Data;
public class LibraryContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Book> Books { get; set; }
  public DbSet<Author> Authors { get; set; }
  public DbSet<Loan> Loans { get; set; }
  public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>(user =>
    {
      user.ToTable("users");
      user.HasKey(u => u.Id);
      user.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("id");
      user.Property(u => u.Name).IsRequired().HasMaxLength(80).HasColumnName("name");
      user.Property(u => u.Email).IsRequired().HasMaxLength(50).HasColumnName("email");
      user.Property(u => u.Password).IsRequired().HasMaxLength(255).HasColumnName("password");
      user.Property(u => u.IdNumber).IsRequired().HasColumnName("id_number");
      user.Property(u => u.Role).IsRequired().HasColumnName("role");
    });

    modelBuilder.Entity<Book>(book =>
    {
      book.ToTable("books");
      book.HasKey(b => b.Id);
      book.Property(b => b.Id).ValueGeneratedOnAdd().HasColumnName("id");
      book.Property(b => b.AuthorId).IsRequired().HasColumnName("author_id");
      book
        .HasOne(b => b.Author) // libro tiene un autor
        .WithMany(a => a.Books) // un autor tiene muchos libros
        .HasForeignKey(b => b.AuthorId);
      book.Property(b => b.Title).IsRequired().HasMaxLength(100).HasColumnName("title");
      book.Property(b => b.Genre).IsRequired().HasMaxLength(50).HasColumnName("genre");
      book.Property(b => b.Status).IsRequired().HasColumnName("status");
      book.Property(b => b.PublicationDate).IsRequired().HasColumnName("publication_date");
    });

    modelBuilder.Entity<Author>(author =>
    {
      author.ToTable("authors");
      author.HasKey(a => a.Id);
      author.Property(a => a.Id).ValueGeneratedOnAdd().HasColumnName("id");
      author.Property(a => a.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
      author.Property(a => a.Nationality).IsRequired().HasMaxLength(50).HasColumnName("nationality");
      author.Property(a => a.Birthdate).IsRequired().HasColumnName("birthdate");
    });

    modelBuilder.Entity<Loan>(loan =>
    {
      loan.ToTable("loans");
      loan.HasKey(l => l.Id);
      loan.Property(l => l.Id).ValueGeneratedOnAdd().HasColumnName("id");
      loan.Property(l => l.BookId).IsRequired().HasColumnName("book_id");
      loan.Property(l => l.UserId).IsRequired().HasColumnName("user_id");

      loan
        .HasOne(l => l.User)
        .WithMany(u => u.Loans)
        .HasForeignKey(l => l.UserId);

      loan
        .HasOne(l => l.Book)
        .WithMany(b => b.Loans)
        .HasForeignKey(l => l.BookId);

      loan.Property(l => l.UserId).IsRequired().HasColumnName("user_id");
      loan.Property(l => l.BookId).IsRequired().HasColumnName("book_id");
      loan.Property(l => l.LoanDate).IsRequired().HasColumnName("loan_date");
      loan.Property(l => l.ReturnDate).IsRequired(false).HasColumnName("return_date");
    });
  }

}