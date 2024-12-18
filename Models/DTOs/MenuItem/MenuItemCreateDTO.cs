namespace RestaurantBookingApi.Models.DTOs.MenuItem
{
  public class MenuItemCreateDTO
  {
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsPopular { get; set; }
  }
}