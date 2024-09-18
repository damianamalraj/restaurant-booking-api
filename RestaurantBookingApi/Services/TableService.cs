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

    public async Task AddTable(TableCreateDTO table)
    {
      await _tableRepository.AddTableAsync(new Table
      {
        TableNumber = table.TableNumber,
        Seats = table.Seats
      });
    }

    public async Task<Table> GetTable(int tableId)
    {
      return await _tableRepository.GetTableAsync(tableId);
    }

    public async Task<IEnumerable<Table>> GetTables()
    {
      return await _tableRepository.GetTablesAsync();
    }

    public async Task UpdateTable(TableUpdateDTO tableUpdateDto)
    {
      var tableToUpdate = await _tableRepository.GetTableAsync(tableUpdateDto.TableId);

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
  }
}