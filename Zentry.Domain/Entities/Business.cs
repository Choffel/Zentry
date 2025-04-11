namespace Zentry.Domain.Entities;

public class Business
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid OwnerId { get; set; }
    public User Owner { get; set; } = null!;
    
    public List<Location> Locations { get; set; } = new();
    public List<Service> Services { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}