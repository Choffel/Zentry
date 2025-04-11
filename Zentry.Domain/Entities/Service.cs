namespace Zentry.Domain.Entities;

public class Service
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }

    public Guid BusinessId { get; set; }
    public Business Business { get; set; } = null!;

    public List<Employee> Employees { get; set; } = new();
    public List<Booking> Bookings { get; set; } = new();
}