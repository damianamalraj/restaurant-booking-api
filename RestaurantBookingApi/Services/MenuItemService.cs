using RestaurantBookingApi.Data.Repositories.IRepositories;
using RestaurantBookingApi.Models.DTOs.MenuItem;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Services
{
  public class MenuItemService : IMenuItemService
  {
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemService(IMenuItemRepository menuItemRepository)
    {
      _menuItemRepository = menuItemRepository;
    }

    public async Task AddMenuItemAsync(MenuItemCreateDTO menuItem)
    {
      await _menuItemRepository.AddMenuItemAsync(new MenuItem
      {
        Name = menuItem.Name,
        IsAvailable = menuItem.IsAvailable,
        Price = menuItem.Price
      });
    }

  }
}