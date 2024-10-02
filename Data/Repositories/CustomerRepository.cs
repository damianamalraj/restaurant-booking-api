using Microsoft.EntityFrameworkCore;
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

    public async Task<Customer> GetCustomerAsync(int id)
    {
      return await _context.Customers.FindAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
      return await _context.Customers.ToListAsync();
    }

    public async Task UpdateCustomerAsync(Customer customer)
    {
      _context.Customers.Update(customer);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(int customerId)
    {
      var customer = await _context.Customers.FindAsync(customerId);
      if (customer == null)
      {
        return;
      }

      _context.Customers.Remove(customer);
      await _context.SaveChangesAsync();

    }
  }
}