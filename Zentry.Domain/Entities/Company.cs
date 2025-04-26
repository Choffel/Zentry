namespace Zentry.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public TimeSpan Duration { get; set; }

    public Guid BusinessId { get; set; }
    public Business Business { get; set; } = null!;

    public List<Employee> Employees { get; set; } = new();
    
    public List<Booking> Bookings { get; set; } = new();
    
    public string CompanyName { get; set; }
    
    public string CompanyAddress { get; set; }
    
    public string CompanyPhone { get; set; }
    
    public string CompanyEmail { get; set; }
    
    public string Website { get; set; }
}