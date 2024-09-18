namespace RestaurantBookingApi.Models.DTOs.Booking
{
  public class BookingCreateDTO
  {
    public int TableId { get; set; }
    public int CustomerId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
  }
}