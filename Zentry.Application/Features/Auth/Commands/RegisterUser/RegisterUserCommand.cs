using MediatR;
using Zentry.Application.DTOs.Identity;

namespace Zentry.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; } = "Client";


    public RegisterUserCommand(string email, string password, string role)
    {
        Email = email;
        Password = password;
        Role = role;
    }

    public RegisterUserCommand(RegisterUserDto dto)
    {
        Email = dto.Email;
        Password = dto.Password;
        Role = dto.Role;
    }
}