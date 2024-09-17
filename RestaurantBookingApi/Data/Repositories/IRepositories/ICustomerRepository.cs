namespace RestaurantBookingApi.Data.Repositories.IRepositories
{
  public interface ICustomerRepository
  {
    Task AddCustomerAsync(Customer customer);
    // Task<Customer> GetCustomer(int customerId);
    // Task<IEnumerable<Customer>> GetCustomers();
    // Task<Customer> UpdateCustomer(Customer customer);
    // Task<Customer> DeleteCustomer(int customerId);
  }
}