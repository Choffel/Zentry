using MediatR;
using Zentry.Application.DTOs.Identity;

namespace Zentry.Application.Features.Employee.Commands.CreateEmployee;


public class CreateEmployeeCommand : IRequest<Guid>
{
    public string FullName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public Guid UserId { get; set; }

    public CreateEmployeeCommand(CreateEmployeeDto dto)
    {
        FullName = dto.FullName;
        Email = dto.Email;
        PhoneNumber = dto.PhoneNumber;
        UserId = (Guid)dto.UserId;
    }
}

