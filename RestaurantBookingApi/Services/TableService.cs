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

    public async Task AddTableAsync(TableCreateDTO table)
    {
      await _tableRepository.AddTableAsync(new Table
      {
        TableNumber = table.TableNumber,
        Seats = table.Seats
      });
    }

    public async Task<Table> GetTable(int tableId)
    {
      return await _tableRepository.GetTable(tableId);
    }

    public async Task<IEnumerable<Table>> GetTables()
    {
      return await _tableRepository.GetTables();
    }

    public async Task<Table> UpdateTable(TableUpdateDTO table)
    {

      var tableToUpdate = await _tableRepository.GetTable(table.Id);

      if (tableToUpdate == null)
      {
        return null;
      }

      tableToUpdate.TableNumber = table.TableNumber;
      tableToUpdate.Seats = table.Seats;

      return await _tableRepository.UpdateTable(tableToUpdate);
    }

    public async Task<Table> DeleteTable(int tableId)
    {
      return await _tableRepository.DeleteTable(tableId);
    }
  }
}