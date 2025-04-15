using MediatR;
using Zentry.Application.Features.Booking.Commands.CreateEmployee;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Application.Features.Employee.Commands.CreateEmployee;


public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly ZentryDbContext _context;

    public CreateEmployeeHandler(ZentryDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Domain.Entities.Employee
        {
            Id = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            UserId = request.UserId
        };
        
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}