using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Data.Repositories.IRepositories;
using RestaurantBookingApi.Models.DTOs.Booking;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Services
{
  public class BookingService : IBookingService
  {

    private readonly IBookingRepository _bookingRepository;
    private readonly ITableRepository _tableRepository;

    public BookingService(IBookingRepository bookingRepository, ITableRepository tableRepository)
    {
      _bookingRepository = bookingRepository;
      _tableRepository = tableRepository;

    }

    public async Task<IActionResult> AddBookingAsync(BookingCreateDTO bookingCreateDto)
    {
      var table = await _tableRepository.GetTableAsync(bookingCreateDto.TableId);

      if (table == null)
      {
        return new NotFoundObjectResult("Table not found");
      }

      if (table.Seats < bookingCreateDto.NumberOfPeople)
      {
        return new BadRequestObjectResult("Table does not have enough seats");
      }

      var existingBooking = await _bookingRepository.GetBookingsAsync();
      if (existingBooking.Any(b => b.TableId == bookingCreateDto.TableId && b.BookingDate.Date == bookingCreateDto.BookingDate.Date))
      {
        return new ConflictObjectResult("Table is already booked for this date");
      }

      await _bookingRepository.AddBookingAsync(new Booking
      {
        CustomerId = bookingCreateDto.CustomerId,
        TableId = bookingCreateDto.TableId,
        BookingDate = bookingCreateDto.BookingDate,
        NumberOfPeople = bookingCreateDto.NumberOfPeople
      });

      return new CreatedResult();
    }

    public async Task<Booking> GetBookingAsync(int bookingId)
    {
      return await _bookingRepository.GetBookingAsync(bookingId);
    }

    public async Task<IEnumerable<Booking>> GetBookingsAsync()
    {
      return await _bookingRepository.GetBookingsAsync();
    }

    public async Task UpdateBookingAsync(BookingUpdateDTO bookingUpdateDto)
    {
      var booking = await _bookingRepository.GetBookingAsync(bookingUpdateDto.BookingId);
      booking.CustomerId = bookingUpdateDto.CustomerId;
      booking.TableId = bookingUpdateDto.TableId;
      booking.BookingDate = bookingUpdateDto.BookingDate;
      booking.NumberOfPeople = bookingUpdateDto.NumberOfPeople;

      await _bookingRepository.UpdateBookingAsync(booking);
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
      await _bookingRepository.DeleteBookingAsync(bookingId);
    }
  }
}