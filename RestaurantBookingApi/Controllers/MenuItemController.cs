using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.MenuItem;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MenuItemController : ControllerBase
  {
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
      _menuItemService = menuItemService;
    }

    [HttpPost]
    [Route("addMenuItem")]
    public async Task<IActionResult> AddMenuItem(MenuItemCreateDTO menuItemCreateDto)
    {
      await _menuItemService.AddMenuItemAsync(menuItemCreateDto);
      return Created();
    }
  }
}