using Library.Application.Services;
using Library.Domain.Repositories;
using Library.Infrastructure;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios de la aplicación
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

// Registrar servicios de aplicación
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LoanService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configuración de la pipeline HTTP
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
