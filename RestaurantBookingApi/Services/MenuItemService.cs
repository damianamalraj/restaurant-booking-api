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

    public async Task<MenuItem> GetMenuItem(int menuItemId)
    {
      return await _menuItemRepository.GetMenuItemAsync(menuItemId);
    }

    public async Task<IEnumerable<MenuItem>> GetMenuItems()
    {
      return await _menuItemRepository.GetMenuItemsAsync();
    }

    public async Task UpdateMenuItem(MenuItemUpdateDTO menuItemUpdateDto)
    {
      var menuItemToUpdate = await _menuItemRepository.GetMenuItemAsync(menuItemUpdateDto.MenuItemId);

      if (menuItemToUpdate == null)
      {
        return;
      }

      menuItemToUpdate.Name = menuItemUpdateDto.Name;
      menuItemToUpdate.IsAvailable = menuItemUpdateDto.IsAvailable;
      menuItemToUpdate.Price = menuItemUpdateDto.Price;

      await _menuItemRepository.UpdateMenuItemAsync(menuItemToUpdate);
    }

    public async Task DeleteMenuItem(int menuItemId)
    {
      await _menuItemRepository.DeleteMenuItemAsync(menuItemId);
    }

  }
}