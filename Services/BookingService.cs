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
      var table = await _tableRepository.GetTableWithTableNumberAsync(bookingCreateDto.TableNumber);
      var customer = await _customerRepository.GetCustomerForBookingAsync(bookingCreateDto.CustomerEmail);
      var bookingExists = await _bookingRepository.BookingExistsAsync(bookingCreateDto.TableNumber, bookingCreateDto.StartBookingDateTime);

      if (customer == null)
      {
        await _customerRepository.AddCustomerAsync(new Customer
        {
          Name = bookingCreateDto.CustomerName,
          Email = bookingCreateDto.CustomerEmail
        });
      }

      if (table == null)
      {
        return new NotFoundObjectResult("Table not found");
      }

      if (table.Seats < bookingCreateDto.NumberOfPeople)
      {
        return new BadRequestObjectResult("Table does not have enough seats");
      }

      if (bookingExists)
      {
        return new ConflictObjectResult("Table is already booked for this date and time");
      }

      if (customer == null)
      {
        customer = await _customerRepository.GetCustomerForBookingAsync(bookingCreateDto.CustomerEmail);
      }

      await _bookingRepository.AddBookingAsync(new Booking
      {
        CustomerId = customer.Id,
        TableId = table.Id,
        TableNumber = table.TableNumber,
        CustomerName = customer.Name,
        CustomerEmail = customer.Email,
        NumberOfPeople = bookingCreateDto.NumberOfPeople,
        StartBookingDateTime = bookingCreateDto.StartBookingDateTime,
        EndBookingDateTime = bookingCreateDto.StartBookingDateTime.AddHours(2),
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
      var table = await _tableRepository.GetTableWithTableNumberAsync(bookingUpdateDto.TableNumber);
      var bookingExists = await _bookingRepository.BookingExistsAsync(bookingUpdateDto.TableNumber, bookingUpdateDto.StartBookingDateTime);
      var customer = await _customerRepository.GetCustomerForBookingAsync(bookingUpdateDto.CustomerEmail);

      if (customer == null)
      {
        await _customerRepository.AddCustomerAsync(new Customer
        {
          Name = bookingUpdateDto.CustomerName,
          Email = bookingUpdateDto.CustomerEmail
        });
      }
      else
      {
        customer.Name = bookingUpdateDto.CustomerName;
        await _customerRepository.UpdateCustomerAsync(customer);
      }

      if (table == null)
      {
        return new NotFoundObjectResult("Table not found");
      }

      if (table.Seats < bookingUpdateDto.NumberOfPeople)
      {
        return new BadRequestObjectResult("Table does not have enough seats");
      }

      if (bookingExists)
      {
        return new ConflictObjectResult("Table is already booked for this date and time");
      }

      if (customer == null)
      {
        customer = await _customerRepository.GetCustomerForBookingAsync(bookingUpdateDto.CustomerEmail);
      }

      booking.CustomerId = customer.Id;
      booking.TableId = table.Id;
      booking.TableNumber = table.TableNumber;
      booking.CustomerName = customer.Name;
      booking.CustomerEmail = customer.Email;
      booking.NumberOfPeople = bookingUpdateDto.NumberOfPeople;
      booking.StartBookingDateTime = bookingUpdateDto.StartBookingDateTime;
      booking.EndBookingDateTime = bookingUpdateDto.StartBookingDateTime.AddHours(2);

      await _bookingRepository.UpdateBookingAsync(booking);

      return new CreatedResult();
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
      await _bookingRepository.DeleteBookingAsync(bookingId);
    }
  }
}