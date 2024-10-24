namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface ICustomerRepository
  {
    Task AddCustomerAsync(Customer customer);
    Task<Customer> GetCustomerAsync(int customerId);
    Task<Customer> GetCustomerForBookingAsync(string email);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task UpdateCustomerAsync(Customer customer);
    Task DeleteCustomerAsync(int customerId);
  }
}