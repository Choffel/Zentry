using MediatR;
using Microsoft.EntityFrameworkCore;
using Zentry.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Настройка MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);

// Настройка DbContext
builder.Services.AddDbContext<ZentryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>() 
    .AddEnvironmentVariables();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();