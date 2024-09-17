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

  }
}