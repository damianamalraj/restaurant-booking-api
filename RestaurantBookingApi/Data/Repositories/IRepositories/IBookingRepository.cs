namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface IBookingRepository
  {
    Task AddBookingAsync(Booking booking);
    Task<Booking> GetBookingAsync(int bookingId);
    Task<IEnumerable<Booking>> GetBookingsAsync();
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(int bookingId);
  }
}