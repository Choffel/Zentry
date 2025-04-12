using MediatR;
using Zentry.Domain.Interfaces;
using Zentry.Domain.Entities;

namespace Zentry.Application.Features.Booking.Commands.CreateBooking
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _repository;

        
        public CreateBookingHandler(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Domain.Entities.Booking
            {
                ServiceId = request.ServiceId,
                EmployeeId = request.EmployeeId,
                StartTime = request.StartTime,
                EndTime = request.EndTime.AddHours(1), 
                Status = BookingStatus.Pending
            };
            
            await _repository.CreateAsync(booking); 
            return booking.Id; 
        }
    }
}