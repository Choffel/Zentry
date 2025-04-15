namespace Zentry.Application.Features.Booking.Commands.CreateEmployee;

public class CreateEmployeeDto
{
    public string FullName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public Guid? UserId { get; set; } 
}