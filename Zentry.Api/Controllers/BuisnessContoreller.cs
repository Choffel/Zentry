using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zentry.Application.DTOs.Company;
using Zentry.Application.Features.Company.Commands.CreateCompany;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Api.Controllers;
[ApiController]
[Route("/api/Buisness")]
public class BuisnessContoreller : ControllerBase
{
    private readonly ZentryDbContext _context;
    private readonly IMediator _mediator;

    public BuisnessContoreller(ZentryDbContext context, IMediator mediator)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpPost("CreateCompany")]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CreateCompanyDto dto)
    {
        var command = new CreateCompanyCommand(dto);

        var companyId = await _mediator.Send(command);

        return Ok(companyId); 
    }
}