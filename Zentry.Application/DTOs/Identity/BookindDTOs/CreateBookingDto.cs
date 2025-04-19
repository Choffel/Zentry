namespace Zentry.Application.DTOs;

public class CreateBookingDto
{
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime AppointmentTime { get; set; }
}