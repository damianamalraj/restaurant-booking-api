using RestaurantBookingApi.Data.Repositories.IRepositories;

namespace RestaurantBookingApi.Data.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly ApplicationContext _context;

    public CustomerRepository(ApplicationContext context)
    {
      _context = context;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
      await _context.Customers.AddAsync(customer);
      await _context.SaveChangesAsync();
    }

  }
}