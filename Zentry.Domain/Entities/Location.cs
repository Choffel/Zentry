namespace Zentry.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string? Coordinates { get; set; }

    public Guid BusinessId { get; set; }
    public Business Business { get; set; } = null!;
}