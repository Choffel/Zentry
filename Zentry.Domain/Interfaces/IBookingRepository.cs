
using Zentry.Domain.Entities;

namespace Zentry.Domain.Interfaces;

public interface IBookingRepository
{
    Task<Guid> CreateAsync(Booking booking);
    Task<Booking> GetByIdAsync(Guid id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(Guid id);
}