namespace Zentry.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public Guid BusinessId { get; set; }
    public Business Business { get; set; } = null!;

    public List<Service> Services { get; set; } = new();
    public List<Booking> Bookings { get; set; } = new();
}