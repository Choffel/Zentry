using Microsoft.EntityFrameworkCore;
using Zentry.Domain.Entities;
using Zentry.Domain.Interfaces;
using Zentry.Infrastructure.Persistence;

namespace Zentry.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ZentryDbContext _context;

    public BookingRepository(ZentryDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();
        
        return booking.Id;
    }

    public async Task<Booking> GetByIdAsync(Guid id)
    {
        return await _context.Bookings.FindAsync(id);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Bookings.Update(booking);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var booking = await GetByIdAsync(id);

        if (booking != null)
        {
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
    }
}