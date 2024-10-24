using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Booking;

namespace RestaurantBookingApi.Services.IServices
{
  public interface IBookingService
  {
    Task<IActionResult> AddBookingAsync(BookingCreateDTO bookingCreateDto);
    Task<Booking> GetBookingAsync(int bookingId);
    Task<IEnumerable<Booking>> GetBookingsAsync();
    Task<IActionResult> UpdateBookingAsync(int bookingId, BookingUpdateDTO bookingUpdateDto);
    Task DeleteBookingAsync(int bookingId);
  }
}