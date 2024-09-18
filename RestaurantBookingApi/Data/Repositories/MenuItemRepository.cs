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

  }
}