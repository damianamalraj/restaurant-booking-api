using Microsoft.AspNetCore.Mvc;
using RestaurantBookingApi.Data.Repositories.IRepositories;
using RestaurantBookingApi.Models.DTOs.Table;
using RestaurantBookingApi.Services.IServices;

namespace RestaurantBookingApi.Services
{
  public class TableService : ITableService
  {
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
      _tableRepository = tableRepository;
    }

    public async Task<IActionResult> AddTable(TableCreateDTO table)
    {
      var tableExists = await _tableRepository.TableExistsAsync(table.TableNumber);

      if (tableExists)
      {
        return new ConflictObjectResult("Table is already added");
      }

      await _tableRepository.AddTableAsync(new Table
      {
        TableNumber = table.TableNumber,
        Seats = table.Seats
      });

      return new CreatedResult();
    }

    public async Task<Table> GetTable(int tableId)
    {
      return await _tableRepository.GetTableAsync(tableId);
    }

    public async Task<IEnumerable<Table>> GetTables()
    {
      return await _tableRepository.GetTablesAsync();
    }

    public async Task UpdateTable(int tableId, TableUpdateDTO tableUpdateDto)
    {
      var tableToUpdate = await _tableRepository.GetTableAsync(tableId);

      if (tableToUpdate == null)
      {
        return;
      }

      tableToUpdate.TableNumber = tableUpdateDto.TableNumber;
      tableToUpdate.Seats = tableUpdateDto.Seats;

      await _tableRepository.UpdateTableAsync(tableToUpdate);
    }

    public async Task DeleteTable(int tableId)
    {
      var tableToDelete = await _tableRepository.GetTableAsync(tableId);

      if (tableToDelete == null)
      {
        return;
      }

      await _tableRepository.DeleteTableAsync(tableId);
    }

    public async Task<IEnumerable<Table>> GetAvailableTables(int numberOfPeople, DateTime startBookingDateTime)
    {
      return await _tableRepository.GetAvailableTablesAsync(numberOfPeople, startBookingDateTime);
    }
  }
}