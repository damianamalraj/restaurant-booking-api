using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Models.DTOs.Table;

namespace RestaurantBookingApi.Services.IServices
{
  public interface ITableService
  {
    Task<IActionResult> AddTable(TableCreateDTO table);
    Task<Table> GetTable(int tableId);
    Task<IEnumerable<Table>> GetTables();
    Task UpdateTable(int tableId, TableUpdateDTO tableUpdateDto);
    Task DeleteTable(int tableId);
    Task<IEnumerable<Table>> GetAvailableTables(int numberOfPeople, DateTime startBookingDateTime);
  }
}