using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Booking;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BookingsController : ControllerBase
  {
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
      _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking(BookingCreateDTO bookingCreateDto)
    {
      return await _bookingService.AddBookingAsync(bookingCreateDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
      return Ok(await _bookingService.GetBookingsAsync());
    }

    [HttpGet]
    [Route("{bookingId}")]
    public async Task<IActionResult> GetBooking(int bookingId)
    {
      return Ok(await _bookingService.GetBookingAsync(bookingId));
    }

    [HttpPut]
    [Route("{bookingId}")]
    public async Task<IActionResult> UpdateBooking(int bookingId, BookingUpdateDTO bookingUpdateDto)
    {
      await _bookingService.UpdateBookingAsync(bookingId, bookingUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("{bookingId}")]
    public async Task<IActionResult> DeleteBooking(int bookingId)
    {
      await _bookingService.DeleteBookingAsync(bookingId);
      return NoContent();
    }
  }
}