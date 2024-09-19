using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.MenuItem;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class MenuItemsController : ControllerBase
  {
    private readonly IMenuItemService _menuItemService;

    public MenuItemsController(IMenuItemService menuItemService)
    {
      _menuItemService = menuItemService;
    }

    [HttpPost]
    public async Task<IActionResult> AddMenuItem(MenuItemCreateDTO menuItemCreateDto)
    {
      await _menuItemService.AddMenuItemAsync(menuItemCreateDto);
      return Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetMenuItems()
    {
      return Ok(await _menuItemService.GetMenuItems());
    }

    [HttpGet]
    [Route("{menuItemId}")]
    public async Task<IActionResult> GetMenuItem(int menuItemId)
    {
      return Ok(await _menuItemService.GetMenuItem(menuItemId));
    }

    [HttpPut]
    [Route("{menuItemId}")]
    public async Task<IActionResult> UpdateMenuItem(int menuItemId, MenuItemUpdateDTO menuItemUpdateDto)
    {
      await _menuItemService.UpdateMenuItem(menuItemId, menuItemUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("{menuItemId}")]
    public async Task<IActionResult> DeleteMenuItem(int menuItemId)
    {
      await _menuItemService.DeleteMenuItem(menuItemId);
      return NoContent();
    }
  }
}