namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface IBookingRepository
  {
    Task AddBookingAsync(Booking booking);
    // Task<Booking> GetBooking(int bookingId);
    // Task<IEnumerable<Booking>> GetBookings();
    // Task<Booking> UpdateBooking(Booking booking);
    // Task<Booking> DeleteBooking(int bookingId);
  }
}