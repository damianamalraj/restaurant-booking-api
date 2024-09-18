namespace RestaurantBookingApi.Models.DTOs.Table
{
  public class TableUpdateDTO
  {
    public int TableId { get; set; }
    public int TableNumber { get; set; }
    public int Seats { get; set; }
  }
}