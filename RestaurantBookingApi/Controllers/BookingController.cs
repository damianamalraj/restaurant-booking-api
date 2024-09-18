using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Booking;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BookingController : ControllerBase
  {
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
      _bookingService = bookingService;
    }

    [HttpPost]
    [Route("addBooking")]
    public async Task<IActionResult> AddBooking(BookingCreateDTO bookingCreateDto)
    {
      return await _bookingService.AddBookingAsync(bookingCreateDto);
    }

    [HttpGet]
    [Route("getBookings")]
    public async Task<IActionResult> GetBookings()
    {
      return Ok(await _bookingService.GetBookingsAsync());
    }

    [HttpGet]
    [Route("getBooking/{bookingId}")]
    public async Task<IActionResult> GetBooking(int bookingId)
    {
      return Ok(await _bookingService.GetBookingAsync(bookingId));
    }

    [HttpPut]
    [Route("updateBooking")]
    public async Task<IActionResult> UpdateBooking(BookingUpdateDTO bookingUpdateDto)
    {
      await _bookingService.UpdateBookingAsync(bookingUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("deleteBooking/{bookingId}")]
    public async Task<IActionResult> DeleteBooking(int bookingId)
    {
      await _bookingService.DeleteBookingAsync(bookingId);
      return NoContent();
    }
  }
}