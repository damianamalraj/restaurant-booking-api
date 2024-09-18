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

    [HttpGet]
    [Route("getMenuItems")]
    public async Task<IActionResult> GetMenuItems()
    {
      return Ok(await _menuItemService.GetMenuItems());
    }

    [HttpGet]
    [Route("getMenuItem/{menuItemId}")]
    public async Task<IActionResult> GetMenuItem(int menuItemId)
    {
      return Ok(await _menuItemService.GetMenuItem(menuItemId));
    }

    [HttpPut]
    [Route("updateMenuItem")]
    public async Task<IActionResult> UpdateMenuItem(MenuItemUpdateDTO menuItemUpdateDto)
    {
      await _menuItemService.UpdateMenuItem(menuItemUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("deleteMenuItem/{menuItemId}")]
    public async Task<IActionResult> DeleteMenuItem(int menuItemId)
    {
      await _menuItemService.DeleteMenuItem(menuItemId);
      return NoContent();
    }
  }
}