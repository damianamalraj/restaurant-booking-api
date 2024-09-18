using Microsoft.EntityFrameworkCore;
using RestaurantBookingApi.Data.Repositories.IRepositories;

namespace RestaurantBookingApi.Data.Repositories
{
  public class TableRepository : ITableRepository
  {
    private readonly ApplicationContext _context;

    public TableRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task AddTableAsync(Table table)
    {
      await _context.Tables.AddAsync(table);
      await _context.SaveChangesAsync();
    }

    public async Task<Table> GetTable(int tableId)
    {
      return await _context.Tables.FindAsync(tableId);
    }

    public async Task<IEnumerable<Table>> GetTables()
    {
      return await _context.Tables.ToListAsync();
    }

    public async Task<Table> UpdateTable(Table table)
    {
      _context.Tables.Update(table);
      await _context.SaveChangesAsync();
      return table;
    }

    public async Task<Table> DeleteTable(int tableId)
    {
      var table = await _context.Tables.FindAsync(tableId);
      if (table == null)
      {
        return null;
      }

      _context.Tables.Remove(table);
      await _context.SaveChangesAsync();
      return table;
    }
  }
}