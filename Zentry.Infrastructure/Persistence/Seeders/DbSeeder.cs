using Zentry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Zentry.Infrastructure.Persistence.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ZentryDbContext context)
        {
            var ownerId = Guid.Parse("11111111-1111-1111-1111-111111111111");

            context.Users.Add(new User
            {
                Id = ownerId,
                Email = "admin@zentry.com",
                Phone = "+123456789",
                Role = "Owner"
            });
            
            
            var businessId = Guid.Parse("99999999-9999-9999-9999-999999999999");

            if (!context.Businesses.Any())
            {
                context.Businesses.Add(new Business()
                {
                    Id = businessId,
                    Name = "Zentry gym",
                    Description = "Premium Gym",
                    OwnerId = ownerId
                });
            }
            
            
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(new List<Employee>
                {
                    new Employee
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        FirstName = "Иван",
                        LastName = "Иванов"
                    },
                    new Employee
                    {
                        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                        FirstName = "Ольга",
                        LastName = "Петрова"
                    }
                });
            }

            if (!context.Services.Any())
            {
                context.Services.AddRange(new List<Service>
                {
                    new Service
                    {
                        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                        Name = "Тренировка в зале"
                    },
                    new Service
                    {
                        Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                        Name = "Йога"
                    }
                });
            }

            await context.SaveChangesAsync();
        }
    }
}