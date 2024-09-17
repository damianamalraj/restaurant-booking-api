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

  }
}