using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zentry.Application.DTOs;
using Zentry.Application.Features.Booking.Commands.CreateBooking;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookingController : Controller
{
    private readonly ZentryDbContext _context;
    private readonly IMediator _mediator;

    public BookingController(IMediator mediator,ZentryDbContext context)
    {
        _context = context;
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        var command = new CreateBookingCommand(dto);
        var result = await _mediator.Send(command);
        
        return Ok(result);
    }

    [HttpGet("Bookings")]
    public async Task<IActionResult> GetBooking()
    {
        var result = await _context.Bookings.ToListAsync();
        
        return Ok(result);
    }

    [HttpGet("Service")]
    public async Task<IActionResult> GetService()
    {
        var result = await _context.Services.ToListAsync();
         
        return Ok(result);
    }
}