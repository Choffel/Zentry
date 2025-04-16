using MediatR;
using Microsoft.AspNetCore.Identity;
using Zentry.Domain.Entities;

namespace Zentry.Application.Features.Auth.Commands.RegisterUser;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand,Guid>
{
    private readonly UserManager<User> _userManager;
    private readonly  RoleManager<IdentityRole> _roleManager;

    public RegisterUserHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (!await _roleManager.RoleExistsAsync(request.Role))
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(request.Role));
            if (!roleResult.Succeeded)
            {
                throw new Exception("Role error");
            }
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            UserName = request.Email,
            Role = request.Role
        };
        
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            throw new Exception("CreateU ser error: " + string.Join("; ", errors));
        }
        
        await _userManager.AddToRoleAsync(user, request.Role);
        
        return user.Id;
    }
}