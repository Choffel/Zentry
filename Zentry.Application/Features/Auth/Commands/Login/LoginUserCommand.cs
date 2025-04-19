using MediatR;
using Zentry.Application.DTOs.Identity;

namespace Zentry.Application.Features.Auth.Commands.Login;

public class LoginUserCommand : IRequest<string>
{
    public string Email { get; set; }
    
    public string Password { get; set; }

    public LoginUserCommand(LoginDto dto)
    {
        Email = dto.Email;
        
        Password = dto.Password;
    }
}