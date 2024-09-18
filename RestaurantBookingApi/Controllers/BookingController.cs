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
      await _bookingService.AddBookingAsync(bookingCreateDto);
      return Created();
    }
  }
}