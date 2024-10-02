namespace RestaurantBookingApi.Models.DTOs.Booking
{
  public class BookingUpdateDTO
  {
    public int TableId { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartBookingDateTime { get; set; }
    public int NumberOfPeople { get; set; }
  }
}