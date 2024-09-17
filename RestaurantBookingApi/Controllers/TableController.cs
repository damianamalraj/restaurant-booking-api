using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Table;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TableController : ControllerBase
  {
    private readonly ITableService _tableService;

    public TableController(ITableService tableService)
    {
      _tableService = tableService;
    }

    [HttpPost]
    [Route("addTable")]
    public async Task<IActionResult> AddTable(TableCreateDTO tableCreateDto)
    {
      await _tableService.AddTableAsync(tableCreateDto);
      return Created();
    }

  }
}