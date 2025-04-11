using Microsoft.EntityFrameworkCore;
using Zentry.Domain.Entities;

namespace Zentry.Infrastructure.Persistence;

public class ZentryDbContext : DbContext
{
    public ZentryDbContext(DbContextOptions<ZentryDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users => Set<User>();
    public DbSet<Business> Businesses => Set<Business>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Category> Categories => Set<Category>();
    
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZentryDbContext).Assembly);
    }
}
