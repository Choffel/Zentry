using Zentry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Zentry.Infrastructure.Persistence;

public static class ZentryDbContextSeeder
{
    public static async Task SeedAsync(ZentryDbContext context)
    {
       
        if (!context.Users.Any())
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "test@example.com",
                Phone = "1234567890"
            };

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FullName = "Test Employee",
                Email = "employee@example.com",
                PhoneNumber = "9876543210",
                UserId = user.Id
            };

            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = "Test Service",
                Description = "Just a sample service",
                Price = 1000
            };

            await context.Users.AddAsync(user);
            await context.Employees.AddAsync(employee);
            await context.Services.AddAsync(service);
            await context.SaveChangesAsync();
        }
    }
}