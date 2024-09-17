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
  }
}