using Zentry.Domain.Entities;

namespace Zentry.Application.Authentication;

public interface IJwtTokenGenerator
{
     string GeneratorToken(User user);
}