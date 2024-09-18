using RestaurantBookingApi.Data.Repositories.IRepositories;
using RestaurantBookingApi.Models.DTOs.Booking;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Services
{
  public class BookingService : IBookingService
  {

    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
      _bookingRepository = bookingRepository;
    }

    public async Task AddBookingAsync(BookingCreateDTO booking)
    {
      await _bookingRepository.AddBookingAsync(new Booking
      {
        CustomerId = booking.CustomerId,
        TableId = booking.TableId,
        BookingDate = booking.BookingDate,
        NumberOfPeople = booking.NumberOfPeople
      });
    }
  }
}