using FluentValidation;

namespace Zentry.Application.Features.Booking.Commands.CreateBooking;

public class CreateBookingValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.ServiceId).NotEmpty().WithMessage("ServiceId is required");
        
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        
        RuleFor(x => x.EmployeeId).NotEmpty().WithMessage("EmployeeId is required");
        
        RuleFor(x => x.StartTime).Must(BeInFuture).WithMessage("Start Time must be in the future");
        
        RuleFor(x => x.EndTime).GreaterThan(x => x.StartTime).WithMessage("End Time must be after start time");
    }

    private bool BeInFuture(DateTime date)
    {
        return date > DateTime.UtcNow;
    }
}