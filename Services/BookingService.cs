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
    private readonly ICustomerRepository _customerRepository;

    public BookingService(IBookingRepository bookingRepository, ITableRepository tableRepository, ICustomerRepository customerRepository)
    {
      _bookingRepository = bookingRepository;
      _tableRepository = tableRepository;
      _customerRepository = customerRepository;
    }

    public async Task<IActionResult> AddBookingAsync(BookingCreateDTO bookingCreateDto)
    {
      var table = await _tableRepository.GetTableWithBookingsAsync(bookingCreateDto.TableNumber);

      if (table == null)
      {
        return new NotFoundObjectResult("Table not found");
      }

      if (table.Seats < bookingCreateDto.NumberOfPeople)
      {
        return new BadRequestObjectResult("Table does not have enough seats");
      }

      var bookingExists = await _bookingRepository.BookingExistsAsync(bookingCreateDto.TableNumber, bookingCreateDto.StartBookingDateTime);
      if (bookingExists)
      {
        return new ConflictObjectResult("Table is already booked for this date and time");
      }

      var customer = await _customerRepository.GetCustomerForBookingAsync(bookingCreateDto.CustomerEmail);

      if (customer == null)
      {
        await _customerRepository.AddCustomerAsync(new Customer
        {
          Name = bookingCreateDto.CustomerName,
          Email = bookingCreateDto.CustomerEmail
        });
      }

      await _bookingRepository.AddBookingAsync(new Booking
      {
        CustomerId = customer.Id,
        TableId = bookingCreateDto.TableNumber,
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

    public async Task<IActionResult> UpdateBookingAsync(int bookingId, BookingUpdateDTO bookingUpdateDto)
    {
      var booking = await _bookingRepository.GetBookingAsync(bookingId);
      var customer = await _customerRepository.GetCustomerForBookingAsync(bookingUpdateDto.CustomerEmail);

      var table = await _tableRepository.GetTableWithBookingsAsync(bookingUpdateDto.TableNumber);

      if (table == null)
      {
        return new NotFoundObjectResult("Table not found");
      }

      if (table.Seats < bookingUpdateDto.NumberOfPeople)
      {
        return new BadRequestObjectResult("Table does not have enough seats");
      }

      var bookingExists = await _bookingRepository.BookingExistsAsync(bookingUpdateDto.TableNumber, bookingUpdateDto.StartBookingDateTime);
      if (bookingExists)
      {
        return new ConflictObjectResult("Table is already booked for this date and time");
      }

      booking.CustomerId = customer.Id;
      booking.TableId = bookingUpdateDto.TableNumber;
      booking.StartBookingDateTime = bookingUpdateDto.StartBookingDateTime;
      booking.EndBookingDateTime = bookingUpdateDto.StartBookingDateTime.AddHours(2);
      booking.NumberOfPeople = bookingUpdateDto.NumberOfPeople;

      await _bookingRepository.UpdateBookingAsync(booking);

      return new CreatedResult();
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
      await _bookingRepository.DeleteBookingAsync(bookingId);
    }
  }
}