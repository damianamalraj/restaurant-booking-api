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

    [HttpGet]
    [Route("getTables")]
    public async Task<IActionResult> GetTables()
    {
      return Ok(await _tableService.GetTables());
    }

    [HttpGet]
    [Route("getTable/{tableId}")]
    public async Task<IActionResult> GetTable(int tableId)
    {
      return Ok(await _tableService.GetTable(tableId));
    }

    [HttpPut]
    [Route("updateTable")]
    public async Task<IActionResult> UpdateTable(TableUpdateDTO tableUpdateDto)
    {
      return Ok(await _tableService.UpdateTable(tableUpdateDto));
    }

    [HttpDelete]
    [Route("deleteTable/{tableId}")]
    public async Task<IActionResult> DeleteTable(int tableId)
    {
      return Ok(await _tableService.DeleteTable(tableId));
    }

  }
}