using MediatR;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Application.Features.Company.Commands.CreateCompany;

public class CreateCompanyHandler :IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly ZentryDbContext _context;


    public CreateCompanyHandler(ZentryDbContext context)
    {
        _context = context;
    }


    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Domain.Entities.Company
        {
            Id = Guid.NewGuid(),
            CompanyName = request.CompanyName,
            Description = request.Description,
            CompanyAddress = request.CompanyAddress,
            CompanyPhone = request.CompanyPhone,
            CompanyEmail = request.CompanyEmail,
            Website = request.Website,
        };
        
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync(cancellationToken);
        
        return company.Id;
    }
}