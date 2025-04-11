namespace Zentry.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Service> Services { get; set; } = new();
}