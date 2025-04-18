using MediatR;
using Zentry.Application.DTOs.Identity;

namespace Zentry.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<Guid>
{
    public string Email { get; set; }
    public string Password { get; set; }
    


    public RegisterUserCommand(string email, string password)
    {
        Email = email;
        Password = password;
        
    }

    public RegisterUserCommand(RegisterUserDto dto)
    {
        Email = dto.Email;
        Password = dto.Password;
    }
}