using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Table;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TablesController : ControllerBase
  {
    private readonly ITableService _tableService;

    public TablesController(ITableService tableService)
    {
      _tableService = tableService;
    }

    [HttpPost]
    public async Task<IActionResult> AddTable(TableCreateDTO tableCreateDto)
    {
      return await _tableService.AddTable(tableCreateDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetTables()
    {
      return Ok(await _tableService.GetTables());
    }

    [HttpGet]
    [Route("{tableId}")]
    public async Task<IActionResult> GetTable(int tableId)
    {
      return Ok(await _tableService.GetTable(tableId));
    }

    [HttpPut]
    [Route("{tableId}")]
    public async Task<IActionResult> UpdateTable(int tableId, TableUpdateDTO tableUpdateDto)
    {
      await _tableService.UpdateTable(tableId, tableUpdateDto);
      return NoContent();
    }

    [HttpDelete]
    [Route("{tableId}")]
    public async Task<IActionResult> DeleteTable(int tableId)
    {
      await _tableService.DeleteTable(tableId);
      return NoContent();
    }

    [HttpPost]
    [Route("available")]
    public async Task<IActionResult> GetAvailableTables(AvailableTablesDTO availableTablesDto)
    {
      return Ok(await _tableService.GetAvailableTables(availableTablesDto.NumberOfPeople, availableTablesDto.StartBookingDateTime));
    }
  }
}