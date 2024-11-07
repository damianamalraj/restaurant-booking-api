namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface ITableRepository
  {
    Task AddTableAsync(Table table);
    Task<Table> GetTableAsync(int tableId);
    Task<IEnumerable<Table>> GetTablesAsync();
    Task UpdateTableAsync(Table table);
    Task DeleteTableAsync(int tableId);

    Task<Table> GetTableWithTableNumberAsync(int tableNumber);
    Task<bool> TableExistsAsync(int tableNumber);
    Task<IEnumerable<Table>> GetAvailableTablesAsync(int numberOfPeople, DateTime startBookingDateTime);
  }
}
