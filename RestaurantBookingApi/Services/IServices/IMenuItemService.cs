using RestaurantBookingApi.Models.DTOs.MenuItem;

namespace RestaurantBookingApi.Services.IServices
{
  public interface IMenuItemService
  {
    Task AddMenuItemAsync(MenuItemCreateDTO menuItem);
    Task<MenuItem> GetMenuItem(int menuItemId);
    Task<IEnumerable<MenuItem>> GetMenuItems();
    Task UpdateMenuItem(int menuItemId, MenuItemUpdateDTO menuItemUpdateDto);
    Task DeleteMenuItem(int menuItemId);
  }
}