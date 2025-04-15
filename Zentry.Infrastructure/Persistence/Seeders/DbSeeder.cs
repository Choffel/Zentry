using Zentry.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Zentry.Infrastructure.Persistence.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ZentryDbContext context)
        {
            var ownerId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var businessId = Guid.Parse("99999999-9999-9999-9999-999999999999");

            if (!await context.Users.AnyAsync())
            {
                context.Users.Add(new User
                {
                    Id = ownerId,
                    Email = "admin@zentry.com",
                    Phone = "+123456789",
                    Role = "Owner"
                });
            }

            if (!await context.Businesses.AnyAsync())
            {
                context.Businesses.Add(new Business()
                {
                    Id = businessId,
                    Name = "Zentry gym",
                    Description = "Premium Gym",
                    OwnerId = ownerId
                });
                await context.SaveChangesAsync(); 
            }

            if (!await context.Employees.AnyAsync())
            {
                context.Employees.AddRange(new List<Employee>
                {
                    new Employee
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        FirstName = "Иван",
                        LastName = "Иванов",
                        BusinessId = businessId,
                    },
                    new Employee
                    {
                        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                        FirstName = "Ольга",
                        LastName = "Петрова",
                        BusinessId = businessId,
                    }
                });
            }

            if (!await context.Services.AnyAsync())
            {
                context.Services.AddRange(new List<Service>
                {
                    new Service
                    {
                        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                        Name = "Тренировка в зале",
                        BusinessId = businessId // <- вот это нужно
                    },
                    new Service
                    {
                        Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                        Name = "Йога",
                        BusinessId = businessId // <- и здесь
                    }
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
