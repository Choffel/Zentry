using System;
using MediatR;
using Zentry.Application.DTOs;

namespace Zentry.Application.Features.Booking.Commands.CreateBooking;

public class CreateBookingCommand : IRequest<Guid>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Guid UserId { get; set; }
    public Guid ServiceId { get; set; }
    public Guid? EmployeeId { get; set; }


    public CreateBookingCommand(CreateBookingDto dto)
    {
        ServiceId = dto.ServiceId;
        EmployeeId = dto.EmployeeId;
        StartTime = dto.AppointmentTime;
        EndTime = dto.AppointmentTime.AddHours(1);
    }
}