using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zentry.Application.DTOs.Identity;
using Zentry.Application.Features.Auth.Commands.RegisterUser;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Api.Controllers;
[ApiController]
[Route("User/Account[controller]")]
public class AccountController : Controller
{
    private readonly ZentryDbContext _context;
    private readonly IMediator _mediator;


    public AccountController(ZentryDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var command = new RegisterUserCommand(dto);
        var userId = await _mediator.Send(command);
        
        return Ok(userId);
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser()
    {
        var result = await _context.Users.ToListAsync();
        
        return Ok(result);
    }
}