using RestaurantBookingApi.Models.DTOs.Booking;

namespace RestaurantBookingApi.Services.IServices
{
  public interface IBookingService
  {
    Task AddBookingAsync(BookingCreateDTO booking);
    // Task<Booking> GetBooking(int bookingId);
    // Task<IEnumerable<Booking>> GetBookings();
    // Task<Booking> UpdateBooking(Booking booking);
    // Task<Booking> DeleteBooking(int bookingId);
  }
}