namespace Zentry.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
   
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Role { get; set; } = "Client"; 

    public List<Booking> Bookings { get; set; } = new();
    public List<Business> OwnedBusinesses { get; set; } = new();
}
public enum UserRole
{
    Client,
    Owner,
    Admin
}