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
      var table = await _tableRepository.GetTableWithBookingsAsync(bookingCreateDto.TableId);

      if (table == null)
      {
        return new NotFoundObjectResult("Table not found");
      }

      if (table.Seats < bookingCreateDto.NumberOfPeople)
      {
        return new BadRequestObjectResult("Table does not have enough seats");
      }

      var bookingExists = await _bookingRepository.BookingExistsAsync(bookingCreateDto.TableId, bookingCreateDto.StartBookingDateTime);
      if (bookingExists)
      {
        return new ConflictObjectResult("Table is already booked for this date and time");
      }

      await _bookingRepository.AddBookingAsync(new Booking
      {
        CustomerId = bookingCreateDto.CustomerId,
        TableId = bookingCreateDto.TableId,
        StartBookingDateTime = bookingCreateDto.StartBookingDateTime,
        EndBookingDateTime = bookingCreateDto.StartBookingDateTime.AddHours(2),
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

    public async Task UpdateBookingAsync(int bookingId, BookingUpdateDTO bookingUpdateDto)
    {
      var booking = await _bookingRepository.GetBookingAsync(bookingId);
      booking.CustomerId = bookingUpdateDto.CustomerId;
      booking.TableId = bookingUpdateDto.TableId;
      booking.StartBookingDateTime = bookingUpdateDto.StartBookingDateTime;
      booking.EndBookingDateTime = bookingUpdateDto.StartBookingDateTime.AddHours(2);
      booking.NumberOfPeople = bookingUpdateDto.NumberOfPeople;

      await _bookingRepository.UpdateBookingAsync(booking);
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
      await _bookingRepository.DeleteBookingAsync(bookingId);
    }
  }
}