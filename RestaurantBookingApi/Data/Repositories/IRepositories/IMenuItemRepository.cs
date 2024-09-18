namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface IMenuItemRepository
  {
    Task AddMenuItemAsync(MenuItem menuItem);
    Task<IEnumerable<MenuItem>> GetMenuItemsAsync();
    Task<MenuItem> GetMenuItemAsync(int menuItemId);
    Task UpdateMenuItemAsync(MenuItem menuItem);
    Task DeleteMenuItemAsync(int menuItemId);
  }
}