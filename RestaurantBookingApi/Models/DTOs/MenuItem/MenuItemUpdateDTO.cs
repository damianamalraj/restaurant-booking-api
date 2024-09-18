namespace RestaurantBookingApi.Models.DTOs.MenuItem
{
  public class MenuItemUpdateDTO
  {
    public int MenuItemId { get; set; }
    public string? Name { get; set; }
    public bool IsAvailable { get; set; }
    public decimal Price { get; set; }
  }
}