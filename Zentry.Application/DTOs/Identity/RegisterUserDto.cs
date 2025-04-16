namespace Zentry.Application.DTOs.Identity;

public class RegisterUserDto
{
    public string Email { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    public string Role { get; set; } = "Client";
}