using Microsoft.EntityFrameworkCore;
using RestaurantBookingApi.Data.Repositories.IRepositories;

namespace RestaurantBookingApi.Data.Repositories
{
  public class BookingRepository : IBookingRepository
  {
    private readonly ApplicationContext _context;

    public BookingRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task AddBookingAsync(Booking booking)
    {
      await _context.Bookings.AddAsync(booking);
      await _context.SaveChangesAsync();
    }

    public async Task<Booking> GetBookingAsync(int bookingId)
    {
      return await _context.Bookings.FindAsync(bookingId);
    }

    public async Task<IEnumerable<Booking>> GetBookingsAsync()
    {
      return await _context.Bookings.ToListAsync();
    }

    public async Task UpdateBookingAsync(Booking booking)
    {
      _context.Bookings.Update(booking);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
      var booking = await _context.Bookings.FindAsync(bookingId);
      if (booking == null)
      {
        return;
      }

      _context.Bookings.Remove(booking);
      await _context.SaveChangesAsync();
    }
  }
}