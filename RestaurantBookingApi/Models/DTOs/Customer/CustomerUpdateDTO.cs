namespace RestaurantBookingApi.Models.DTOs.Customer
{
  public class CustomerUpdateDTO
  {
    public int CustomerId { get; set; }
    public string? Name { get; set; }
    public string? ContactInfo { get; set; }
  }
}