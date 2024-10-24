namespace RestaurantBookingApi.Models.DTOs.Booking
{
  public class BookingUpdateDTO
  {
    public int TableNumber { get; set; }
    public string? CustomerEmail { get; set; }
    public DateTime StartBookingDateTime { get; set; }
    public int NumberOfPeople { get; set; }
  }
}