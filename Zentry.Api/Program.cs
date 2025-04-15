using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Zentry.Application.Features.Booking.Commands.CreateBooking;
using Zentry.Domain.Interfaces;
using Zentry.Infrastructure.Persistence;
using Zentry.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(CreateBookingCommand).Assembly));


builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddFluentValidationClientsideAdapters(); 

builder.Services.AddDbContext<ZentryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ZentryDbContext>();
    await ZentryDbContextSeeder.SeedAsync(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();