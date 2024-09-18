using RestaurantBookingApi.Models.DTOs.Table;

namespace RestaurantBookingApi.Services.IServices
{
  public interface ITableService
  {
    Task AddTableAsync(TableCreateDTO table);
    Task<Table> GetTable(int tableId);
    Task<IEnumerable<Table>> GetTables();
    Task<Table> UpdateTable(TableUpdateDTO table);
    Task<Table> DeleteTable(int tableId);
  }
}