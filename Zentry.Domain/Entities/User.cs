using Microsoft.AspNetCore.Identity;

namespace Zentry.Domain.Entities;

public class User : IdentityUser<Guid>
{
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