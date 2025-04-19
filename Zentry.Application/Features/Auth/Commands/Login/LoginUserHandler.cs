using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Zentry.Application.Authentication;
using Zentry.Domain.Entities;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Application.Features.Auth.Commands.Login;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginUserHandler(ZentryDbContext context, IJwtTokenGenerator jwtTokenGenerator, UserManager<User> userManager)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedAccessException("Invalid username or password");
        }
        
        var token  = _jwtTokenGenerator.GeneratorToken(user);
        
        return token;
    }
}