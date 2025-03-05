using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using API.Middlewares;
using API.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddOpenApi();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

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
