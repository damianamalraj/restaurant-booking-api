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

    public async Task<Table> GetTableAsync(int tableId)
    {
      return await _context.Tables.FindAsync(tableId);
    }

    public async Task<IEnumerable<Table>> GetTablesAsync()
    {
      return await _context.Tables.ToListAsync();
    }

    public async Task UpdateTableAsync(Table table)
    {
      _context.Tables.Update(table);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteTableAsync(int tableId)
    {
      var table = await _context.Tables.FindAsync(tableId);
      if (table == null)
      {
        return;
      }

      _context.Tables.Remove(table);
      await _context.SaveChangesAsync();
    }

    public async Task<Table> GetTableWithTableNumberAsync(int tableNumber)
    {
      return await _context.Tables
                  .Include(t => t.Bookings)
                  .FirstOrDefaultAsync(t => t.TableNumber == tableNumber);
    }

    public async Task<bool> TableExistsAsync(int tableNumber)
    {
      return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
    }

    public async Task<IEnumerable<Table>> GetAvailableTablesAsync(int numberOfPeople, DateTime startBookingDateTime)
    {
      DateTime endBookingDateTime = startBookingDateTime.AddHours(2);
      return await _context.Tables
                  .Where(t => t.Seats >= numberOfPeople &&
                    !t.Bookings.Any(b => b.StartBookingDateTime <= endBookingDateTime && b.EndBookingDateTime >= startBookingDateTime))
                  .ToListAsync();
    }
  }
}