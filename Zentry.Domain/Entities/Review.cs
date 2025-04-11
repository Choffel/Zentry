namespace Zentry.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public int Rating { get; set; } 
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid BusinessId { get; set; }
    public Business Business { get; set; } = null!;
}