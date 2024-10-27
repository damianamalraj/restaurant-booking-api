namespace RestaurantBookingApi.Models.DTOs.Booking
{
  public class BookingCreateDTO
  {
    public int TableNumber { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public int NumberOfPeople { get; set; }
    public DateTime StartBookingDateTime { get; set; }
  }
}