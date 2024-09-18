namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface IMenuItemRepository
  {
    Task AddMenuItemAsync(MenuItem menuItem);
    // Task<IEnumerable<MenuItem>> GetMenuItems();
    // Task<MenuItem> GetMenuItem(int menuItemId);
    // Task<MenuItem> UpdateMenuItem(MenuItem menuItem);
    // Task<MenuItem> DeleteMenuItem(int menuItemId);
  }
}