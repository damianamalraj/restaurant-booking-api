using RestaurantBookingApi.Models.DTOs.Table;

namespace RestaurantBookingApi.Services.IServices
{
  public interface ITableService
  {
    Task AddTable(TableCreateDTO table);
    Task<Table> GetTable(int tableId);
    Task<IEnumerable<Table>> GetTables();
    Task UpdateTable(TableUpdateDTO tableUpdateDto);
    Task DeleteTable(int tableId);
  }
}