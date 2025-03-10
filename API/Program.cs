using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using API.Middlewares;
using API.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(); //todo: 
builder.Services.AddControllers(); //todo:

// Add services to the container.
builder.Services.AddDbContext<NotesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddOpenApi();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INoteService, NoteService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection(); //todo:

app.UseAuthorization(); //todo:

// custom middleware
app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware begin");
    await next();
    Console.WriteLine("Middleware end");
});


app.UseRequestMiddleware();


app.UseTimeMiddleware();

app.MapControllers();

app.Run();
