namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface ITableRepository
  {
    Task AddTableAsync(Table table);
    // Task<Table> GetTable(int tableId);
    // Task<IEnumerable<Table>> GetTables();
    // Task<Table> UpdateTable(Table table);
    // Task<Table> DeleteTable(int tableId);
  }
}
