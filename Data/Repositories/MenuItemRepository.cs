using Microsoft.EntityFrameworkCore;
using RestaurantBookingApi.Data.Repositories.IRepositories;

namespace RestaurantBookingApi.Data.Repositories
{
  public class MenuItemRepository : IMenuItemRepository
  {
    private readonly ApplicationContext _context;

    public MenuItemRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task AddMenuItemAsync(MenuItem menuItem)
    {
      await _context.MenuItems.AddAsync(menuItem);
      await _context.SaveChangesAsync();
    }

    public async Task<MenuItem> GetMenuItemAsync(int menuItemId)
    {
      return await _context.MenuItems.FindAsync(menuItemId);
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItemsAsync()
    {
      return await _context.MenuItems.ToListAsync();
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
      _context.MenuItems.Update(menuItem);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(int menuItemId)
    {
      var menuItem = await _context.MenuItems.FindAsync(menuItemId);
      if (menuItem == null)
      {
        return;
      }

      _context.MenuItems.Remove(menuItem);
      await _context.SaveChangesAsync();

    }
  }
}