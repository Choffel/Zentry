namespace Zentry.Application.DTOs;

public class BookingDto
{
    public Guid Id { get; set; }
    public Guid ServiceId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime AppointmentTime { get; set; }
    public DateTime CreatedAt { get; set; }
}